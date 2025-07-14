using Challenge.Application.Interface;
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
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardApplication _application;
        private readonly AppSettings _appSettings;

        public DashboardController(IDashboardApplication application, IOptions<AppSettings> appSettings)
        {
            _application = application;
            _appSettings = appSettings.Value;
        }

        [HttpGet("ListAlertas")]
        public async Task<IActionResult> ListAlertas(int rolId)
        {
            if (rolId ==0)
            {
                return BadRequest();
            }

            var response = await _application.ListAlertas(rolId);
            return Ok(response);
        }

        [HttpGet("ListLeads")]
        public async Task<IActionResult> ListLeads([FromQuery]ReporteLeadsRequest req)
        {
            if (req.estado == null)
            {
                req.estado = string.Empty;
            }

            var response = await _application.ListLeads(req.empresaId, req.productoId??0, req.estado??"");
            return Ok(response);
        }

        [HttpPost("ExportMonthlyLeads")]
        public async Task<IActionResult> ExportMonthlyLeads([FromQuery] ReporteLeadsRequest req)
        {
            if (req.estado == null)
            {
                req.estado = string.Empty;
            }

            var response = await _application.ExportMonthlyLeads(req.empresaId, req.estado ?? "", req.productoId ?? 0);

            string fileName = "EXCEL-" + DateTime.Now.ToString() + ".xlsx";
            string fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            if (response.IsSuccess)
                return File(response.Data, fileType, fileName);

            return BadRequest("No se pudo descargar el Excel");

        }

    }
}
