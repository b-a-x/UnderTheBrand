using Microsoft.AspNetCore.Mvc;
using UnderTheBrand.Domain.Core.Entities;
using UnderTheBrand.Domain.Core.Values;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Presentation.Server.Controllers.Interfaces;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller, IBaseController
    {
        private readonly IBaseService _service;
        private readonly IPersonProvider _provider;

        public BaseController(IBaseService service, IPersonProvider provider)
        {
            _service = service;
            _provider = provider;
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get()
        {
            var name = new Name("Ilia");
            _provider.Create(new Person(new PersonalName(name, name), new Age(28)));
            return Ok(_provider.Read());
        }
    }
}
