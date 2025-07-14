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
    }
}
