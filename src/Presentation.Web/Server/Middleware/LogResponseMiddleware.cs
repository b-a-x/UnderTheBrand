using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UnderTheBrand.Presentation.Web.Server.Middleware
{
    public class LogResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LogResponseMiddleware> logger;
        private readonly LogLevel logLevel;

        public LogResponseMiddleware(RequestDelegate next, ILogger<LogResponseMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
            this.logLevel = LogLevel.Information;
        }

        public async Task Invoke(HttpContext context)
        {
            if (logger.IsEnabled(logLevel))
            {
                Stream originalResponseBody = context.Response.Body;
                var responseBodyStream = new MemoryStream();
                context.Response.Body = responseBodyStream;

                await next(context);

                responseBodyStream.Seek(0, SeekOrigin.Begin);

                logger.Log(logLevel, MessageBuild(context, new StreamReader(responseBodyStream).ReadToEnd()));

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalResponseBody);
            }
            else
            {
                await next(context);
            }
        }

        private static string MessageBuild(HttpContext context, string body)
        {
            var sb = new StringBuilder(body.Length);
            sb.Append("TRACE IDENTIFIER= ");
            sb.Append(context.TraceIdentifier);
            sb.Append(", ");
            sb.Append("BODY= ");
            sb.Append(body);

            return sb.ToString();
        }
    }
}