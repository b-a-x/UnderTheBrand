using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Presentation.Server.Middlewares
{
    // TODO: тест
    public class ErrorHandlingMiddleware
    {
        private const string _internalServerError = "Internal Server Error";
        private const string _innerException = "Internal Server Error (Inner Exception)";
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, _internalServerError);
            if (exception is AggregateException aex && aex.InnerExceptions?.Count > 0)
                foreach (Exception aexInnerException in aex.InnerExceptions)
                    _logger.LogError(aexInnerException, _innerException);


            var error = new Error(HttpStatusCode.InternalServerError.ToString(), exception.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
