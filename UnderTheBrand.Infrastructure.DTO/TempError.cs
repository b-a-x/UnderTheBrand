using System;

namespace UnderTheBrand.Infrastructure.DTO
{
    public class TempError
    {
        public TempError(Exception source)
        {
            FromException(source);
        }

        private void FromException(Exception source)
        {
            ErrorCode = source.HResult;
            Message = source.Message;
            StackTrace = source.StackTrace;
            InnerExceptionMessage = source.InnerException?.Message;
            InnerExceptionStackTrace = source.InnerException?.StackTrace;
        }

        public TempError(AggregateException source)
        {
            if (source?.InnerExceptions != null)
            {
                foreach (var innerException in source.InnerExceptions)
                {
                    FromException(innerException);
                    break;
                }
            }
        }

        public int ErrorCode { get; set; }

        public string StackTrace { get; set; }

        public string InnerExceptionMessage { get; set; }

        public string InnerExceptionStackTrace { get; set; }
        
        public string Message { get; set; }
    }
}