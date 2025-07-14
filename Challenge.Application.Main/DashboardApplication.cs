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
using System.Reflection;

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
        public async Task<Response<byte[]>> ExportMonthlyLeads(int empresaId, string estado, int productoId)
        {
            var response = new Response<byte[]>();
            try
            {
                var leads = await ListLeads(empresaId, productoId, estado);
                var data = leads.Data;

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Leads");

                var propiedades = typeof(ReporteLeadWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                for (int i = 0; i < propiedades.Length; i++)
                {
                    var cell = worksheet.Cell(1, i + 1);
                    cell.Value = propiedades[i].Name;

                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                    cell.Style.Font.FontColor = XLColor.White;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                }

                for (int row = 0; row < data.Count; row++)
                {
                    var item = data[row];
                    for (int col = 0; col < propiedades.Length; col++)
                    {
                        var value = propiedades[col].GetValue(item);
                        var cell = worksheet.Cell(row + 2, col + 1);
                        cell.Value = value?.ToString() ?? "";

                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        cell.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    }
                }

                worksheet.Columns().AdjustToContents();

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
        public async Task<Response<int>> CountLeadsCurrentMonth()
        {
            var response = new Response<int>();
            try
            {
                response.Data = await _domain.CountLeadsCurrentMonth();

                if (response.Data >= 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Leads visualizados correctamente";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "No hay leads en el mes actual";
                }
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = $"Error: {e.Message}";
            }

            return response;
        }

        public async Task<Response<int>> GetLeadCountByPlan(int empresaId)
        {
            var response = new Response<int>();
            try
            {
                if (empresaId <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "El Id de la empresa no puede ser menor o igual a cero.";
                    return response;
                }

                response.Data = await _domain.GetLeadCountByPlan(empresaId);

                if (response.Data > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Leads visualizados correctamente.";
                }
              
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = $"Error: {e.Message}";
            }

            return response;
        }

    }
}
