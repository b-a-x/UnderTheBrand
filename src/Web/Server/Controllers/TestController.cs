using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Interface.Entities;
using UnderTheBrand.Domain.Interface.Repositories;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Domain.ValueObject.ValidationAttributes;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Infrastructure.Core.Extensions;
using UnderTheBrand.Infrastructure.Core.Utils;
using UnderTheBrand.Infrastructure.SqliteDal.Context;
using UnderTheBrand.Infrastructure.SqliteDal.InitializeDB;

namespace UnderTheBrand.Presentation.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        private readonly IPersonRepository _repository;
        private readonly IManagerInitialize _manager;
        private readonly ApplicationContext _context;

        public TestController(IPersonRepository repository,
                              IManagerInitialize manager,
                              ApplicationContext context)
        {
            _context = context;
            _repository = repository;
            _manager = manager;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            //TODO: ответ мапить в dto
            return Ok(await _context.Persons.ToArrayAsync());
        }

        public class PersonViewModel
        {
            [Name]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        [HttpPost("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonViewModel vm)
        {
            Result<Name> firstName = Name.Create(vm.FirstName);
            Result<Name> lastName = Name.Create(vm.LastName);
            Result<Age> age = Age.Create(vm.Age);
            PersonalName personalName = new PersonalName(firstName.Value, lastName.Value);
            Person person = new Person(personalName, age.Value);
            await _context.Persons.AddAsync(person);
            _context.SaveChanges();
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

        [HttpGet("GetListSortId")]
        public IActionResult GetListSortId()
        {
            return Ok(_context.Persons.AsNoTracking().FilterAndSort(new PagedQuery<IPerson>()).ToArray());
        }

        [HttpGet("Initialize")]
        public IActionResult Initialize()
        {
            _manager.Initialize();

            return Ok();
        }

        [HttpGet("FilterSortAndPaginate")]
        public IActionResult FilterSortAndPaginate()
        {
            return Ok(_context.Persons.AsNoTracking().FilterSortAndPaginate(new PagedQuery<IPerson>
            {
                Paging = new Paging(1, 5)
            }));
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            return Ok(_repository.GetList());
        }
    }
}
