using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.ValueObject.Helpers
{
    public static class Errors
    {
        public static class Age
        {
            public static Error IsInvalid(int age) =>
                new Error("age.is.invalid", $"Age '{age}' is invalid");
        }
        public static class Person
        {
            public static Error NameIsTaken(string name) => 
                new Error("person.name.is.taken", $"Student name '{name}' is taken");
        }
        public static class General
        {
            public static Error NotFound(string entityName, string id) =>
                new Error("general.record.not.found", $"'{entityName}' not found for Id '{id}'");

            public static Error NotFound() =>
                new Error("general.not.found", "Not found");

            public static Error ValueIsInvalid() =>
                new Error("general.value.is.invalid", "Value is invalid");

            public static Error ValueIsEmpty(string value) =>
                new Error("general.value.is.empty", $"'{value}' can't be empty");
        }
    }
}
