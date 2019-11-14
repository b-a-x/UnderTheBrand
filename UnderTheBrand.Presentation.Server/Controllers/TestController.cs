using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.Core.Entities;
using UnderTheBrand.Domain.Core.Values;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Infrastructure.DTO.Entities;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    //[Produces("application/json")]
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
                Result<Name> name = Name.Create("Ilia");
                _provider.Create(new Person(new PersonalName(name.Value, name.Value), Age.Create(28).Value));
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

        [HttpPost(nameof(UpdatePerson))]
        public IActionResult UpdatePerson([FromBody] PersonDTO dto)
        {
            try
            {
                LogMethodBegin();
                
                
                LogMethodEnd(dto);

                return Ok(dto);
            }
            catch (Exception e)
            {
                LogMethodError(e);
                throw;
            }
        }
    }
}
