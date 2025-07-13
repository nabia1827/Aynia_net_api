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
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardApplication _application;
        private readonly AppSettings _appSettings;

        public DashboardController(IDashboardApplication application, IOptions<AppSettings> appSettings)
        {
            _application = application;
            _appSettings = appSettings.Value;
        }
    }
}
