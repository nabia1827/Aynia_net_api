using AutoMapper;
using Challenge.Application.Interface;
using Challenge.Application.Wrapper;
using Challenge.Application.DTO;
using Challenge.Domain.Entity;
using Challenge.Domain.Interface;
using Challenge.Infrastructure.Interface;
using Challenge.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Challenge.Application.Main
{
    public class DashboardApplication : IDashboardApplication
    {
        private readonly IDashboardDomain _domain;
        private readonly IMapper _mapper;

        public DashboardApplication(IDashboardDomain domain, IMapper iMapper)
        {
            _domain = domain;
            _mapper = iMapper;
        }

        public async Task<Response<List<AlertaDto>>> ListAlertas(int rolId)
        {
            var response = new Response<List<AlertaDto>>();
            try
            {
                var items = await _domain.ListAlertas(rolId);

                response.Data = _mapper.Map<List<AlertaDto>>(items);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<ReporteLeadWrapper>>> ListLeads(int empresaId, int productoId, string estado)
        {
            var response = new Response<List<ReporteLeadWrapper>>();
            try
            {
                var items = await _domain.ListLeads(empresaId, productoId, estado);

                response.Data = items;

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<byte[]>> ExportMonthlyLeads(string estado, int productoId)
        {
            var response = new Response<byte[]>();
            try
            {
                var leads = new List<(string Nombre, string Correo, string Producto)>
                {
                    ("Juan Perez", "juan.perez@ejemplo.com", "Seguro Hogar"),
                    ("Ana Gómez", "ana.gomez@ejemplo.com", "Crédito Personal"),
                    ("Carlos Ruiz", "carlos.ruiz@ejemplo.com", "Cuenta Corriente")
                };

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Leads");

                // Cabeceras
                worksheet.Cell("A1").Value = "Nombre";
                worksheet.Cell("B1").Value = "Correo";
                worksheet.Cell("C1").Value = "Producto";

                // Formato cabecera: negrita, fondo azul, texto blanco, centrado y bordes
                var headerRange = worksheet.Range("A1:C1");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                headerRange.Style.Font.FontColor = XLColor.White;
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                for (int i = 0; i < leads.Count; i++)
                {
                    int row = i + 2;
                    worksheet.Cell(row, 1).Value = leads[i].Nombre;
                    worksheet.Cell(row, 2).Value = leads[i].Correo;
                    worksheet.Cell(row, 3).Value = leads[i].Producto;

                    var rowRange = worksheet.Range(row, 1, row, 3);
                    rowRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rowRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    rowRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    rowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                }

                worksheet.Columns(1, 3).AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);

                response.Message = "Documento generado exitosamente.";
                response.IsSuccess = true;
                response.Data = stream.ToArray();
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
