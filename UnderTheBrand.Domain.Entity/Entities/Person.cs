using System;
using UnderTheBrand.Domain.Entity.Base;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Entity.Entities
{
    public class Person : HasId
    {
        protected Person() { }

        public Person(PersonalName personalName, Age age)
        {
            Age = age ?? throw new ArgumentNullException(nameof(age));
            PersonalName = personalName ?? throw new ArgumentNullException(nameof(personalName));
        }

        public PersonalName PersonalName { get; set; }

        public Age Age { get; set; }

        /*private List<CityInPerson> _cities;

        public IReadOnlyCollection<City> Cities =>
            _cities
                .Select(x => x.City)
                .ToList();

        public void AddCity(City city)
        {
            _cities.Add(new CityInPerson(city, this));
        }*/
    }
}
