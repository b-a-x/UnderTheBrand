using System;
using System.Collections.Generic;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    /// <summary>
    /// Личное имя
    /// </summary>
    public class PersonalName : ValueObject
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

        public override bool Equals(object obj)
        {
            return obj is PersonalName personalName &&
                   EqualityComparer<Name>.Default.Equals(FirstName, personalName.FirstName) &&
                   EqualityComparer<Name>.Default.Equals(LastName, personalName.LastName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
