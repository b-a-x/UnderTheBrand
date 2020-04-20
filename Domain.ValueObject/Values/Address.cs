using System.Collections.Generic;

namespace UnderTheBrand.Domain.ValueObject.Values
{
    public class Address : Core.Base.ValueObject
    {
        protected Address() { }

        private Address(string street, int zipCode, string comment)
        {
            Street = street;
            ZipCode = zipCode;
            Comment = comment;
        }

        public string Street { get; }
        public int ZipCode { get; }
        public string Comment { get; }

        public static Result<Address> Create(string street, int zipCode, string comment)
        {
            if (string.IsNullOrWhiteSpace(street))
                return Result.Fail<Address>("Street can't be empty");

            if (string.IsNullOrWhiteSpace(comment))
                return Result.Fail<Address>("Comment can't be empty");

            return Result.Ok(new Address(street, zipCode, comment));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return ZipCode;
            yield return Comment;
        }
    }
}
