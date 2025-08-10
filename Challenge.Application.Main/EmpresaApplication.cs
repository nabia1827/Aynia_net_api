using AutoMapper;
using Challenge.Domain.Entity;
using Challenge.Domain.Interface;
using AutoMapper;
using Challenge.Transversal.Common;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Application.DTO;
using Challenge.Application.Interface;

namespace Challenge.Application.Main
{
    public class EmpresaApplication: IEmpresaApplication
    {
        private readonly IEmpresaDomain _empresaDomain;
        private readonly IMapper _mapper;

        public EmpresaApplication(IEmpresaDomain empresaDomain, IMapper iMapper)
        {
            _empresaDomain = empresaDomain;
            _mapper = iMapper;
        }
        public async Task<Response<bool>> EditDatosEmpresaById(Empresa empresa)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _empresaDomain.EditDatosEmpresaById(empresa);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se modifico la empresa correctamente!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<EmpresaDto>> GetDatosEmpresaById(int empresaId)
        {
            var response = new Response<EmpresaDto>();
            try
            {
                var empresa = await _empresaDomain.GetDatosEmpresaById(empresaId);

                response.Data = _mapper.Map<EmpresaDto>(empresa);

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
