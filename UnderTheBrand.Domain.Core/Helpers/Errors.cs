using UnderTheBrand.Domain.Core.Values;

namespace UnderTheBrand.Domain.Core.Helpers
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
            public static Error NotFound(string entityName, long id) =>
                new Error("record.not.found", $"'{entityName}' not found for Id '{id}'");
        }
    }
}
