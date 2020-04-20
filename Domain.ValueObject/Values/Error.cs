using System;
using System.Collections.Generic;
using UnderTheBrand.Domain.ValueObject.Utils;

namespace UnderTheBrand.Domain.ValueObject.Values
{
    public sealed class Error : Core.Base.ValueObject
    {
        private const string Separator = "||";

        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        public string Serialize()
        {
            return $"{Code}{Separator}{Message}";
        }

        public static Error Deserialize(string serialized)
        {
            string[] data = serialized.Split(
                new[] { Separator },
                StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                //    throw new ArgumentNullException($"Invalid error serialization: '{serialized}'");}
            {
                return Errors.General.SystemValueIsInvalid(data[0]);
            }

            return new Error(data[0], data[1]);
        }
    }
}
