using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Infrastructure.DTO;

namespace UnderTheBrand.Presentation.Server.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ApiExceptionFilter> _logger;

        protected ApiExceptionFilter() { }

        public ApiExceptionFilter(IWebHostEnvironment env, ILogger<ApiExceptionFilter> logger)
        {
            _environment = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, nameof(ApiExceptionFilter));

            var error = new Error(HttpStatusCode.InternalServerError.ToString(), context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(error);
        }
    }
}