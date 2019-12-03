using System;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Entity.Entities
{
    public class CityInPerson : Base.Entity
    {
        protected CityInPerson() { }

        public CityInPerson(City city, Person person)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
            Person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public City City { get; protected set; }

        public Person Person { get; protected set; }
    }
}
