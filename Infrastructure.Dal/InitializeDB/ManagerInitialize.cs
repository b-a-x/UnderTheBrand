using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Domain.Model.Values;
using UnderTheBrand.Infrastructure.Dal.Context;

namespace UnderTheBrand.Infrastructure.Dal.InitializeDB
{
    public class ManagerInitialize : IManagerInitialize
    {
        private readonly int _totalCount = 1000000;
        private readonly int _takeCount = 50;
        private readonly object _lock = new object();
        private readonly List<Person> _listPersons = new List<Person>();
        
        public void Initialize()
        {
            InitializePerson();
        }

        private void InitializePerson()
        {
            for (int i = 0; i < _totalCount; i++)
            {
                Result<Name> firstName = Name.Create("LocationStatus");
                Result<Name> lastName = Name.Create("LocationStatus");
                Result<Age> age = Age.Create(10);
                PersonalName personalName = new PersonalName(firstName.Value, lastName.Value);
                _listPersons.Add(new Person(personalName, age.Value) { Id = Guid.NewGuid() });
            }

            Parallel.For(0, _totalCount / _takeCount, new ParallelOptions {MaxDegreeOfParallelism = 4}, AddRange);
        }

        private void AddRange(int i)
        {
            using var context = new UnderTheBrandContext();
            context.Persons.AddRange(_listPersons.Skip(i * _takeCount).Take(_takeCount));
            context.SaveChanges();
        }
    }
}
