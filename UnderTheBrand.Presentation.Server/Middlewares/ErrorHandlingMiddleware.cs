using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace UnderTheBrand.Presentation.Server.Middlewares
{
    // TODO: тест
    public class ErrorHandlingMiddleware
    {
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
            //TODO: Логировать все
            if (exception is AggregateException aex && aex.InnerExceptions?.Count > 0)
                exception = aex.InnerExceptions[0];

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(exception, nameof(HttpStatusCode.InternalServerError));

            //TODO: Не отображается информация об ошибке в браузере
            //return context.Response.WriteAsync(JsonConvert.SerializeObject(new Error(exception)));
            //TODO: Сделать объект ответа и записи в логи ошибок
            return context.Response.WriteAsync(JsonConvert.SerializeObject(exception));
        }
    }
}
