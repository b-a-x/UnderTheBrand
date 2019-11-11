using System;
using System.Text.RegularExpressions;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    /// <summary>
    /// Имя
    /// </summary>
    public class Name : ValueObject
    {
        private static readonly Regex ValidationRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}]{1,100}\z",
            RegexOptions.Singleline | RegexOptions.Compiled);

        private const string ErrorValidate = nameof(Name) + Validate;

        protected Name() { }

        public Name(string value)
        {
            if (!IsValid(value)) throw new ArgumentException(ErrorValidate);
            Value = value;
        }

        public string Value { get; }

        public static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Name other &&
                   StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }
    }
}
