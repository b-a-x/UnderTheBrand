using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnderTheBrand.Domain.ValueObject.Values
{
    /// <summary>
    /// Имя
    /// </summary>
    public class Name : Core.Base.ValueObject
    {
        private static readonly Regex ValidationRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}]{1,100}\z",
            RegexOptions.Singleline | RegexOptions.Compiled);

        protected Name() { }

        private Name(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Name> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Fail<Name>("Name can't be empty");

            input = input.Trim();
            if (input.Length > 256)
                return Result.Fail<Name>("Name is too long");

            if (!ValidationRegex.IsMatch(input))
                return Result.Fail<Name>("Name is invalid");

            return Result.Ok(new Name(input));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
