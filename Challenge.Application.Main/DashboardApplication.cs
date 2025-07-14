using AutoMapper;
using Challenge.Application.Interface;
using Challenge.Domain.Entity;
using Challenge.Domain.Interface;
using Challenge.Infrastructure.Interface;
using Challenge.Transversal.Common;
using Newtonsoft.Json.Linq;
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
