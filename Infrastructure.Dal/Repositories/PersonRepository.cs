using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Extensions;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Domain.Model.Entities;

namespace UnderTheBrand.Infrastructure.Dal.Repositories
{
    public class PersonRepository : EntityRepository<Person>, IPersonRepository
    {
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
            return _context.Persons.AsNoTracking().FilterAndSort(new PagedQuery<Person>()).ToArray();
        }
    }
}
