using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnderTheBrand.Domain.Core.Infrastructure;
using UnderTheBrand.Domain.Entity.Entities;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Infrastructure.ViewModel.Entities;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        private readonly IPersonRepository _repository;

        public TestController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            //TODO: ответ мапить в dto
            return Ok(await _repository.GetAllAsync());
        }

        [HttpPost("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonViewModel vm)
        {
            Result<Name> firstName = Name.Create(vm.FirstName);
            Result<Name> lastName = Name.Create(vm.LastName);
            Result<Age> age = Age.Create(vm.Age);
            PersonalName personalName = new PersonalName(firstName.Value, lastName.Value);
            Person person = new Person(personalName, age.Value);
            person = await _repository.AddAsync(person);
            _repository.SaveChanges();
            //TODO: ответ мапить в dto
            return Ok(person);
        }

        [HttpGet("FastTypeInfo")]
        public IActionResult FastTypeInfo()
        {
            Result<Name> firstName = Name.Create("Ilia");
            Result<Name> lastName = Name.Create("Ilia");
            Result<Age> age = Age.Create(25);
            PersonalName personalName = new PersonalName(firstName.Value, lastName.Value);
            var att = FastTypeInfo<Person>.Attributes;
            var metoInfos = FastTypeInfo<Person>.PublicMethods;
            var prop = FastTypeInfo<Person>.PublicProperties;
            Person person = FastTypeInfo<Person>.Create(personalName, age.Value);
            var method = FastTypeInfo<Person>.PropertyGetter<Person, PersonalName>("PersonalName");
            var method2 = FastTypeInfo<Person>.PropertySetter<Person, PersonalName>("PersonalName");

            return Ok(person);
        }
    }
}
