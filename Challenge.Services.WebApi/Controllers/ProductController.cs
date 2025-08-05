using Challenge.Application.Interface;
using Challenge.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Challenge.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _application;
        private readonly AppSettings _appSettings;

        public ProductController(IProductApplication application, IOptions<AppSettings> appSettings)
        {
            _application = application;
            _appSettings = appSettings.Value;
        }

        [HttpPost("ImportProducts")]
        public async Task<IActionResult> ImportProducts(int empresaId, IFormFile file)
        {
            if (empresaId == 0)
            {
                return BadRequest();
            }

            var response = await _application.ImportProducts(file, empresaId);
            return Ok(response);
        }
    }
}
