using PommaLabs.Thrower;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Entity.Entities
{
    public class Person : Core.Base.EntityObject
    {
        protected Person() { }

        public Person(PersonalName personalName, Age age)
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
