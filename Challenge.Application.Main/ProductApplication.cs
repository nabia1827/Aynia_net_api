using AutoMapper;
using Challenge.Application.Interface;
using Challenge.Domain.Entity;
using Challenge.Domain.Interface;
using Challenge.Transversal.Common;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Main
{
    public class ProductApplication: IProductApplication
    {
        private readonly IProductDomain _domain;
        private readonly IMapper _mapper;

        public ProductApplication(IProductDomain domain, IMapper iMapper)
        {
            _domain = domain;
            _mapper = iMapper;
        }

        public async Task<Response<bool>> ImportProducts(IFormFile file, int empresaId)
        {
            var response = new Response<bool>();

            if (file == null || file.Length == 0)
            {
                response.IsSuccess = false;
                response.Message = "El archivo no puede estar vacío.";
                return response;
            }

            var extension = Path.GetExtension(file.FileName);
            if (extension != ".xlsx")
            {
                response.IsSuccess = false;
                response.Message = "Solo se permiten archivos con extensión .xlsx.";
                return response;
            }

            List<Product> products = new List<Product>();

            try
            {
                using (var stream = file.OpenReadStream())
                using (var workbook = new XLWorkbook(stream))
                {
                    var hoja = workbook.Worksheet(1);
                    var filas = hoja.RowsUsed().ToList();

                    if (filas.Count < 2)
                    {
                        response.IsSuccess = false;
                        response.Message = "El archivo debe contener al menos una fila de cabecera y una fila de datos.";
                        return response;
                    }

                    var cabecera = filas[0];
                    var columnas = hoja.ColumnsUsed().ToList();

                    foreach (var fila in filas.Skip(1))
                    {
                        try
                        {
                            // Validamos celdas requeridas (nombre, precio y stock)
                            var nombre = fila.Cell(1).GetValue<string>();
                            var precioStr = fila.Cell(2).GetString();
                            var stockStr = fila.Cell(3).GetString();

                            if (string.IsNullOrWhiteSpace(nombre) ||
                                !decimal.TryParse(precioStr, out var precio) ||
                                !int.TryParse(stockStr, out var stock))
                            {
                                // Saltamos fila invalida
                                continue;
                            }

                            var producto = new Product
                            {
                                Nombre = nombre,
                                Precio = precio,
                                Stock = stock,
                                EmpresaId = empresaId
                            };

                            // Creacion del json de categorias
                            if (columnas.Count > 3)
                            {
                                producto.DescripcionJSON = "";

                                var dict = new Dictionary<string, string>();
                                for (int i = 4; i <= columnas.Count; i++)
                                {
                                    var clave = cabecera.Cell(i).GetValue<string>();
                                    var valor = fila.Cell(i).GetValue<string>();
                                    if (!string.IsNullOrWhiteSpace(clave))
                                        dict[clave] = valor;
                                }
                                producto.DescripcionJSON = JsonConvert.SerializeObject(dict);
                            }

                            products.Add(producto);
                        }
                        catch
                        {
                            
                            continue;
                        }
                    }
                }

                if (products.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron productos válidos en el archivo.";
                    return response;
                }

                var result = await _domain.InsertProducts(products);

                if (result)
                {
                    response.IsSuccess = true;
                    response.Data = true;
                    response.Message = "Se han importado los productos correctamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Data = false;
                    response.Message = "Ocurrió un error al momento de importar.";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Data = false;
                response.Message = $"Error al procesar el archivo: {ex.Message}";
                return response;
            }
        }

    }
}
