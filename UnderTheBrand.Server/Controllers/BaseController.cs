using Microsoft.AspNetCore.Mvc;
using UnderTheBrand.Domain.Core;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Presentation.Server.Controllers.Interfaces;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/base")]
    public class BaseController : Controller, IBaseController
    {
        private readonly IBaseService _service;
        private readonly ITestProvider _provider;

        public BaseController(IBaseService service, ITestProvider provider)
        {
            _service = service;
            _provider = provider;
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get()
        {
            _provider.Create(new Test("Ilia"));
            return Ok(_provider.Read());
        }
    }
}
