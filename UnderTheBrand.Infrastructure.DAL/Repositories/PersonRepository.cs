using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Business.Entities;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Infrastructure.DAL.Context;

namespace UnderTheBrand.Infrastructure.DAL.Repositories
{
    public class PersonRepository : EntityRepository<Person>, IPersonRepository
    {
        protected PersonRepository() { }

        public PersonRepository(UnderTheBrandContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Person>> GetList()
        {
            return await _context.Persons
                .OrderBy(p => p.PersonalName.LastName.Value)
                .ThenBy(p => p.PersonalName.FirstName.Value)
                .ToListAsync();
        }
    }
}
