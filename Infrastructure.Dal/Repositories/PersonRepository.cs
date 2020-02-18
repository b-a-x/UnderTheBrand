using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Extensions;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Domain.Model.Entities;
using Dapper;

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

        public PagedResponse<Person> FilterSortAndPaginate()
        {
            return _context.Persons.AsNoTracking().FilterSortAndPaginate(new PagedQuery<Person>
            {
                Paging = new Paging(1, 5)
            });
        }

        public PagedResponse<Person> GetList()
        {
            int limit = 30;
            int offset = 0;

            using (var connection = new SqliteConnection("Data Source=Database_UnderTheBrand.db"))
            {
                connection.Open();
                int total = connection.Query<int>("SELECT COUNT(*) as count FROM Persons").First();
                //IEnumerable<Person> output = connection.Query<Person>("SELECT Id FROM Persons");
                var query = "SELECT Id FROM Persons ORDER BY Id DESC Limit @Limit Offset @Offset";
                IEnumerable<Person> output = connection.Query<Person>(query, new { Limit = limit, Offset = offset });

                var result = new PagedResponse<Person>(output, total, total/limit);

                return result;
            }
        }
    }
}
