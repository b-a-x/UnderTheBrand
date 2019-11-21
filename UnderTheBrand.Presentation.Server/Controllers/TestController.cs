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
            LogMethodBegin();

            Result<Name> name = Name.Create("Ilia");
            Result<Age> age = Age.Create(28);
            PersonalName personalName = new PersonalName(name.Value, name.Value);
            Person person = new Person(personalName, age.Value);
            
            _repository.Create(person);

            IReadOnlyCollection<Person> persons = _repository.Read();

            LogMethodEnd(persons);

            return Ok(persons);
        }

        [HttpPost(nameof(UpdatePerson))]
        public IActionResult UpdatePerson([FromBody] PersonDto dto)
        {
            LogMethodBegin(dto);

            Result<Name> firstName = Name.Create(dto.FirstName);
            Result<Name> lastName = Name.Create(dto.LastName);
            Result<Age> age = Age.Create(dto.Age);
            PersonalName personalName = new PersonalName(firstName.Value, lastName.Value);
            Person person = new Person(personalName, age.Value);

            LogMethodEnd(person);

            return Ok(person);
        }
    }
}
