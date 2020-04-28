using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using UnderTheBrand.Domain.Core.Base;
using Dapper;
using UnderTheBrand.Domain.Interface.Entities;
using UnderTheBrand.Domain.Interface.Repositories;

namespace UnderTheBrand.Infrastructure.SqliteDal.Repositories
{
    //TODO: Подумать в сторону CQRS
    public class PersonRepository : IPersonRepository
    {
        public PagedResponse<IPerson> GetList()
        {
            int limit = 30;
            int offset = 0;

            using var connection = new SqliteConnection("Data Source=Database_UnderTheBrand.db");
            connection.Open();
            int total = connection.Query<int>("SELECT COUNT(*) as count FROM Persons").First();
            //IEnumerable<Person> output = connection.Query<Person>("SELECT Id FROM Persons");
            var query = "SELECT Id FROM Persons ORDER BY Id DESC Limit @Limit Offset @Offset";
            IEnumerable<IPerson> output = connection.Query<IPerson>(query, new { Limit = limit, Offset = offset });
            var result = new PagedResponse<IPerson>(output, total, total / limit);

            return result;
        }
    }
}