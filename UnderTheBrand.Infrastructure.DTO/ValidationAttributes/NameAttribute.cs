using System;
using System.ComponentModel.DataAnnotations;
using UnderTheBrand.Domain.Core.Values;

namespace UnderTheBrand.Infrastructure.DTO.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string name = value as string;
            if (name == null) return new ValidationResult("Тип не соответсвует string");

            Result<Name> emailResult = Name.Create(name);
            if (emailResult.Failure) return new ValidationResult(emailResult.Error.Serialize());

            return ValidationResult.Success;
        }
    }
}
