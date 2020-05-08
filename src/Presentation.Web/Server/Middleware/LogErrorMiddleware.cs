using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.Model.Values;

namespace UnderTheBrand.Presentation.Web.Server.Middleware
{
    // TODO: тест
    public class LogErrorMiddleware
    {
        private const string _internalServerError = "Internal Server Error";
        private const string _innerException = "Internal Server Error (Inner Exception)";
        private readonly RequestDelegate _next;
        private readonly ILogger<LogErrorMiddleware> _logger;

        public LogErrorMiddleware(RequestDelegate next, ILogger<LogErrorMiddleware> logger)
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
            _logger.LogError(_internalServerError, exception);
            if (exception is AggregateException aex && aex.InnerExceptions.Count > 0)
                foreach (Exception aexInnerException in aex.InnerExceptions)
                    _logger.LogError(_innerException, aexInnerException);


            var error = new Error(nameof(HttpStatusCode.InternalServerError), exception.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}