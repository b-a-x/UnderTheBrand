using Microsoft.AspNetCore.Mvc;
using UnderTheBrand.Presentation.Server.Controllers.Interfaces;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    internal class BaseController : Controller, IBaseController
    {
        private readonly IBaseService _service;

        internal BaseController(IBaseService service)
        {
            _service = service;
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
