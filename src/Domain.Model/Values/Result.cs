using System;
using System.Collections.Generic;

namespace UnderTheBrand.Domain.Model.Values
{
    public class Result : Base.ValueObject
    {
        public bool Success { get; }
        public Error Error { get; }

        public bool Failure => !Success;

        protected Result(bool success, string error)
        {
            if (success && !string.IsNullOrEmpty(error))
                throw new ArgumentNullException();

            if (!success && string.IsNullOrEmpty(error))
                throw new ArgumentNullException();

            Success = success;
            Error = new Error("", error);
        }

        protected Result(bool success, Error error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default, false, message);
        }

        public static Result<T> Fail<T>(Error error)
        {
            return new Result<T>(default, false, error);
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
        private T value;

        public T Value
        {
            get
            {
                if (!Success) throw new ArgumentNullException();

                return value;
            }

            private set => this.value = value;
        }

        public Result(T value, bool success, string error)
            : base(success, error)
        {
            if (value != null && !Success) throw new ArgumentNullException();

            this.Value = value;
        }

        public Result(T value, bool success, Error error)
            : base(success, error)
        {
            if (value != null && !Success) throw new ArgumentNullException();

            this.Value = value;
        }
    }
}
