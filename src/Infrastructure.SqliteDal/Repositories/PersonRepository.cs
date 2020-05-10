using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Domain.Model.Interfaces;

namespace UnderTheBrand.Infrastructure.SqliteDal.Repositories
{
    //TODO: Подумать в сторону CQRS
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection connection;

        public PersonRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Person[] GetAll()
        {
            int limit = 30;
            int offset = 0;

            int total = connection.Query<int>("SELECT COUNT(*) as count FROM Persons").First();
            var query = "SELECT Id FROM Persons ORDER BY Id DESC Limit @Limit Offset @Offset";
            IEnumerable<Person> output = connection.Query<Person>(query, new { Limit = limit, Offset = offset });
            return output.ToArray();
        }
    }
}