using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace UnderTheBrand.Presentation.Web.Server.Middleware
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogRequestMiddleware> _logger;

        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //TODO: Читать запросы с уровнем логирования info
            var requestBodyStream = new MemoryStream();
            Stream originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            string url = context.Request.GetDisplayUrl();
            string requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
            _logger.LogInformation($"REQUEST URL: {url}, REQUEST METHOD: {context.Request.Method}, REQUEST BODY: {requestBodyText}");
            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await _next(context);
            context.Request.Body = originalRequestBody;
        }
    }
}
