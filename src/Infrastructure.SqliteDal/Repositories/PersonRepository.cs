using System;
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
        private const string query = "SELECT Id FROM Persons ORDER BY Id DESC Limit @Limit Offset @Offset";
        private readonly Func<IDbConnection> dbConnection;

        public PersonRepository(Func<IDbConnection> dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public Person[] GetAll()
        {
            int limit = 30;
            int offset = 0;
            using IDbConnection connection = this.dbConnection();
            int total = connection.Query<int>("SELECT COUNT(*) as count FROM Persons").First();
            return connection.Query<Person>(query, new { Limit = limit, Offset = offset }).ToArray();
        }
    }
}