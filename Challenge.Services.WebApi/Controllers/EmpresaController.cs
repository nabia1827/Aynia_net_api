using Challenge.Application.Interface;
using Challenge.Domain.Entity;
using Challenge.Services.WebApi.Helpers;
using Challenge.Services.WebApi.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;

namespace Challenge.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaApplication _application;
        private readonly AppSettings _appSettings;

        public EmpresaController(IEmpresaApplication application, IOptions<AppSettings> appSettings)
        {
            _application = application;
            _appSettings = appSettings.Value;
        }

        [HttpPost("GetDatosEmpresaById")]
        public async Task<IActionResult> GetDatosEmpresaById(int empresaId)
        {
            if (empresaId == 0)
            {
                return BadRequest();
            }

            var response = await _application.GetDatosEmpresaById(empresaId);
            return Ok(response);
        }


        [HttpPost("EditDatosEmpresaById")]
        public async Task<IActionResult> EditDatosEmpresaById([FromQuery] EmpresaRequest req)
        {
            if (req.EmpresaId == null)
            {
                return BadRequest();
            }

            var empresa = new Empresa();
            empresa.EmpresaId = req.EmpresaId;
            empresa.Correo = req.Correo;
            empresa.Direccion = req.Direccion;
            empresa.Telefono = req.Telefono;
            empresa.ZonaEntrega = req.ZonaEntrega;

            var response = await _application.EditDatosEmpresaById(empresa);
            return Ok(response);
        }
    }
}
