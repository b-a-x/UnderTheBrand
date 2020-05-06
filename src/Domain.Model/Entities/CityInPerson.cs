using System;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Model.Entities
{
    public class CityInPerson : Base.Entity
    {
        protected CityInPerson() { }

        public CityInPerson(City city, Person person)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
            Person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public City City { get; }

        public Person Person { get; }
    }
}