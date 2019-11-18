using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UnderTheBrand.Infrastructure.DTO;

namespace UnderTheBrand.Presentation.Server.Middlewares
{
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
                //_logger.LogInformation(await FormatRequest(context.Request));

                await _next(context);
            }
            catch (Exception ex)
            {
                
                await HandleExceptionAsync(context, ex);
            }
        }
        /*
        private async Task<string> FormatRequest(HttpRequest request)
        {
            byte[] buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            string bodyAsText = Encoding.UTF8.GetString(buffer);
            
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString}";
        }
        */
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is AggregateException aex && aex.InnerExceptions?.Count > 0)
                exception = aex.InnerExceptions[0];

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(exception, nameof(HttpStatusCode.InternalServerError));

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new TempError(exception)));
        }
    }
}
