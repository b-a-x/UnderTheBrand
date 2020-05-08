using System;
using UnderTheBrand.Domain.Model.Values;

namespace UnderTheBrand.Domain.Model.Entities
{
    public class Person : Base.Entity
    {
        protected Person() { }

        public Person(PersonalName personalName, Age age)
        {
            Age = age ?? throw new ArgumentNullException(nameof(age));
            PersonalName = personalName ?? throw new ArgumentNullException(nameof(personalName));
        }

        public PersonalName PersonalName { get; }

        public Age Age { get; }

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