using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Extensions;
using UnderTheBrand.Domain.Entity.Entities;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Infrastructure.Dal.Context;

namespace UnderTheBrand.Infrastructure.Dal.Repositories
{
    public class PersonRepository : EntityRepository<Person>, IPersonRepository
    {
        protected PersonRepository() { }

        public PersonRepository(UnderTheBrandContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Person>> GetListSortPersonalName()
        {
            return await _context.Persons
                .OrderBy(p => p.PersonalName.LastName.Value)
                .ThenBy(p => p.PersonalName.FirstName.Value)
                .AsNoTracking()
                .ToListAsync();
        }

        public IReadOnlyCollection<Person> GetListSortId()
        {
            return _context.Persons
                .AsNoTracking().
                FilterAndSort(new PagedQuery<Person>()).ToArray();
        }
    }
}
