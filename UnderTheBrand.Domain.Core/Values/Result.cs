using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    public class Result : ValueObject
    {
        public bool Success { get; private set; }
        public Error Error { get; private set; }

        public bool Failure => !Success;

        protected Result(bool success, string error)
        {
            if (success && !string.IsNullOrEmpty(error))
                throw new ArgumentNullException();

            if (!success && string.IsNullOrEmpty(error))
                throw new ArgumentNullException();

            Success = success;
            Error = new Error("",error);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T), false, message);
        }

        public static Result Ok()
        {
            return new Result(true, String.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, String.Empty);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.Failure)
                    return result;
            }

            return Ok();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }


    public sealed class Result<T> : Result
    {
        private T _value;

        public T Value
        {
            get
            {
                if (!Success) throw new ArgumentNullException();

                return _value;
            }
            [param: AllowNull]

            private set => _value = value;
        }

        protected internal Result([AllowNull] T value, bool success, string error)
            : base(success, error)
        {
            if (value != null && !Success) throw new ArgumentNullException();

            Value = value;
        }
    }
}
