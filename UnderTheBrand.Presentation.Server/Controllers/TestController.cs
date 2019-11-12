using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.Core.Entities;
using UnderTheBrand.Domain.Core.Values;
using UnderTheBrand.Domain.Interfaces.Providers;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        private readonly IPersonProvider _provider;

        public TestController(ILoggerFactory logger,
                              IPersonProvider provider) : base(logger)
        {
            _provider = provider;
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get()
        {
            try
            {
                LogMethodBegin();

                Name name = new Name("Ilia");
                _provider.Create(new Person(new PersonalName(name, name), new Age(28)));
                IReadOnlyCollection<Person> persons = _provider.Read();

                LogMethodEnd(persons);

                return Ok(persons);
            }
            catch (Exception e)
            {
                LogMethodError(e);
                throw;
            }
        }
    }
}
