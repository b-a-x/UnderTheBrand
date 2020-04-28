﻿using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UnderTheBrand.Presentation.Web.Server.Middleware
{
    public class LogResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogResponseMiddleware> _logger;
        private readonly LogLevel _logLevel;

        public LogResponseMiddleware(RequestDelegate next, ILogger<LogResponseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _logLevel = LogLevel.Information;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_logger.IsEnabled(_logLevel))
            {
                Stream originalResponseBody = context.Response.Body;
                var responseBodyStream = new MemoryStream();
                context.Response.Body = responseBodyStream;

                await _next(context);

                responseBodyStream.Seek(0, SeekOrigin.Begin);

                _logger.Log(_logLevel, MessageBuild(context, new StreamReader(responseBodyStream).ReadToEnd()));

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalResponseBody);
            }
            else
            {
                await _next(context);
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