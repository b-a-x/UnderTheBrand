using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get()
        {
            //TODO: ответ мапить в dto
            return Ok(await _repository.GetList());
        }

        [HttpPost(nameof(UpdatePerson))]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonViewModel vm)
        {
            Result<Name> firstName = Name.Create(vm.FirstName);
            Result<Name> lastName = Name.Create(vm.LastName);
            Result<Age> age = Age.Create(vm.Age);
            PersonalName personalName = new PersonalName(firstName.Value, lastName.Value);
            Person person = new Person(personalName, age.Value);
            person = await _repository.CreateAsync(person);
            //TODO: ответ мапить в dto
            return Ok(person);
        }
    }
}
