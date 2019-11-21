using System;
using PommaLabs.Thrower;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Business.Entities
{
    public class Person : Entity
    {
        protected Person() { }

        public Person(PersonalName personalName, Age age) : base(Guid.NewGuid().ToString())
        {
            Raise.ArgumentNullException.IfIsNull(personalName, nameof(personalName));
            Raise.ArgumentNullException.IfIsNull(age, nameof(age));
            Age = age;
            PersonalName = personalName;
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
