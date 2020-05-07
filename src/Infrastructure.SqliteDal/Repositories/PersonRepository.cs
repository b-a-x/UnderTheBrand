using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnderTheBrand.Domain.Core.Base;
using Dapper;
using UnderTheBrand.Domain.Interface.Entities;
using UnderTheBrand.Domain.Interface.Repositories;
using UnderTheBrand.Domain.Model.Entities;

namespace UnderTheBrand.Infrastructure.SqliteDal.Repositories
{
    //TODO: Подумать в сторону CQRS
    public class PersonRepository : IPersonRepository
    {
        private IDbConnection _connection;

        public PersonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public PagedResponse<IPerson> GetList()
        {
            int limit = 30;
            int offset = 0;

            int total = _connection.Query<int>("SELECT COUNT(*) as count FROM Persons").First();
            var query = "SELECT Id FROM Persons ORDER BY Id DESC Limit @Limit Offset @Offset";
            IEnumerable<IPerson> output = _connection.Query<Person>(query, new { Limit = limit, Offset = offset });

            var result = new PagedResponse<IPerson>(output, total, total / limit);

            return result;
        }
    }
}