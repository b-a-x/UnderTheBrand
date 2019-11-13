﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    /// <summary>
    /// Имя
    /// </summary>
    public class Name : ValueObject, IValueObjectValidation<string>
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

        public bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
