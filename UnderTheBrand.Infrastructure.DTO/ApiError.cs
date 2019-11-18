using System;
using System.Net;

namespace UnderTheBrand.Infrastructure.DTO
{
    public class ApiError
    {
        public ApiError()
        {
        }

        public int StatusCode { get; set; }

        public string StackTrace { get; set; }

        public string Message { get; set; }
    }
}