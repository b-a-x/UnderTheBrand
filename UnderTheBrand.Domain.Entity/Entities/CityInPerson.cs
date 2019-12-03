using PommaLabs.Thrower;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Entity.Entities
{
    public class CityInPerson : Core.Base.HasIdBase
    {
        protected CityInPerson() { }

        public CityInPerson(City city, Person person)
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
