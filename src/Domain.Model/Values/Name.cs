using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnderTheBrand.Domain.Model.Utils;

namespace UnderTheBrand.Domain.Model.Values
{
    /// <summary>
    /// Имя
    /// </summary>
    public class Name : Base.ValueObject
    {
        private static readonly Regex ValidationRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}]{1,100}\z",
            RegexOptions.Singleline | RegexOptions.Compiled);

        protected Name() { }

        private Name(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public static Result<Name> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Fail<Name>(Errors.General.ValueIsEmpty(nameof(Name)));

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