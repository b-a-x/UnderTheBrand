using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnderTheBrand.Domain.Model.Values
{
    public class Email : Base.ValueObject
    {
        protected Email() { }

        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Fail<Email>("E-mail can't be empty");

            if (email.Length > 100)
                return Result.Fail<Email>("E-mail is too long");

            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                return Result.Fail<Email>("E-mail is invalid");

            return Result.Ok(new Email(email));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}