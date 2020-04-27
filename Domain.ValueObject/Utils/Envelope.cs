using System;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.ValueObject.Utils
{
    public class Envelope<T>
    {
        protected Envelope() { }
        protected Envelope(T result)
        {
            Result = result;
            TimeGenerated = DateTime.UtcNow;
        }

        public T Result { get; }

        public DateTime TimeGenerated { get; }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result);
        }
    }

    public sealed class Envelope : Envelope<string>
    {
        public string Message { get; }

        private Envelope(string message)
            : base(string.Empty)
        {
            Message = message;
        }

        public static Envelope Ok()
        {
            return new Envelope(string.Empty);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }

    public sealed class EnvelopeError : Envelope<Error>
    {
        public string InvalidField { get; }

        private EnvelopeError(Error error, string invalidField)
            : base(error)
        {
            InvalidField = invalidField;
        }

        public static EnvelopeError Error(Error error, string invalidField)
        {
            return new EnvelopeError(error, invalidField);
        }
    }
}
