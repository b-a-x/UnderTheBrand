using System;
using System.ComponentModel.DataAnnotations;
using UnderTheBrand.Domain.Model.Utils;
using UnderTheBrand.Domain.Model.Values;

namespace UnderTheBrand.Domain.Model.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            if (!(value is string name)) return new ValidationResult(Errors.General.ValueIsInvalid().Serialize());
            Result<Name> emailResult = Name.Create(name);
            if (emailResult.Failure) return new ValidationResult(emailResult.Error.Serialize());

            return ValidationResult.Success;
        }
    }
}
