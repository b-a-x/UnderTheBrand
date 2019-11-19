using System;
using PommaLabs.Thrower;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Business.Entities
{
    public class CityInPerson : Entity
    {
        protected CityInPerson() { }

        public CityInPerson(City city, Person person) : base(Guid.NewGuid())
        {
            Raise.ArgumentNullException.IfIsNull(city, nameof(city));
            Raise.ArgumentNullException.IfIsNull(person, nameof(person));

            City = city;
            Person = person;
        }

        public City City { get; protected set; }

        public Person Person { get; protected set; }
    }
}
