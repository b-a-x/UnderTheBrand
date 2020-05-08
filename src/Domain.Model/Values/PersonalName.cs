using System;
using System.Collections.Generic;

namespace UnderTheBrand.Domain.Model.Values
{
    /// <summary>
    /// Личное имя
    /// </summary>
    public class PersonalName : Base.ValueObject
    {
        protected PersonalName() { }

        public PersonalName(Name firstName, Name lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public Name FirstName { get; }

        public Name LastName { get; }

        public string FullName => $"{FirstName.Value} {LastName.Value}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}