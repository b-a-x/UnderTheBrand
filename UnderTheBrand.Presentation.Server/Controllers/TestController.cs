using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.Business.Entities;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Infrastructure.DTO.Entities;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        private readonly IPersonRepository _repository;

        public TestController(ILoggerFactory logger,
            IPersonRepository repository) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get()
        {
            Result<Name> name = Name.Create("Ilia");
            _repository.Create(new Person(new PersonalName(name.Value, name.Value), Age.Create(28).Value));
            IReadOnlyCollection<Person> persons = _repository.Read();
            
            return Ok(persons);
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
