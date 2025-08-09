using Challenge.Application.Interface;
using Challenge.Services.WebApi.Helpers;
using Challenge.Services.WebApi.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Challenge.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadApplication _application;
        private readonly AppSettings _appSettings;

        public LeadController(ILeadApplication application, IOptions<AppSettings> appSettings)
        {
            _application = application;
            _appSettings = appSettings.Value;
        }

        [HttpGet("ArrayCardLead")]
        public async Task<IActionResult> ArrayCardLead([FromQuery] ArrayLeadsRequest req)
        {
            if (req.empresaId == 0)
            {
                return BadRequest();
            }

            var response = await _application.ArrayLeads(req.empresaId, req.mes ?? 0, req.anio ?? 0, req.valorBusqueda ?? "");
            return Ok(response);
        }
    }
}
