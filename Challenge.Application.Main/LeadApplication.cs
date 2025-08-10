using AutoMapper;
using Challenge.Application.Interface;
using Challenge.Application.Wrapper;
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
    public class LeadApplication: ILeadApplication
    {
        private readonly ILeadDomain _domain;
        private readonly IMapper _mapper;

        public LeadApplication(ILeadDomain domain, IMapper iMapper)
        {
            _domain = domain;
            _mapper = iMapper;
        }

        public async Task<Response<List<ArrayLeadWrapper>>> ArrayLeads(int empresaId, int mes, int anio, string valorBusqueda)
        {
            var response = new Response<List<ArrayLeadWrapper>>();
            try
            {
                var items = await _domain.ArrayLeads(empresaId, mes, anio, valorBusqueda);

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
