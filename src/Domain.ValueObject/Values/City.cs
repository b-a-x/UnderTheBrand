using System.Collections.Generic;

namespace UnderTheBrand.Domain.ValueObject.Values
{
    public sealed class City : Core.Base.ValueObject
    {
        public string Name { get; }
        public bool IsEnabled { get; }

        public City(string name, bool isEnabled)
        {
            Name = name;
            IsEnabled = isEnabled;
        }

        public static Result<City> Create(string name, bool value)
        {
            return Result.Ok(new City(name, value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}