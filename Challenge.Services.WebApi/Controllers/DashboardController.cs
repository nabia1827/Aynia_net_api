using Challenge.Application.Interface;
using Challenge.Application.Main;
using Challenge.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet("CountLeadsCurrentMonth")]
        public async Task<IActionResult> CountLeadsCurrentMonth()
        {
            var response = await _application.CountLeadsCurrentMonth();

            return Ok(response);
        }

        [HttpGet("GetLeadCountByPlan")]
        public async Task<IActionResult> GetLeadCountByPlan(int empresaId)
        {
            if (empresaId <= 0 || empresaId == null)
                return BadRequest();

            var response = await _application.GetLeadCountByPlan((int)empresaId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
