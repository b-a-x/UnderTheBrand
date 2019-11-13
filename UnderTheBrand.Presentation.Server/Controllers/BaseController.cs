using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Presentation.Server.Controllers.Interfaces;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase, IBaseController
    {
        private readonly IBaseService _service;
        private readonly ILogger _logger;

        protected BaseController() { }

        protected BaseController(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger(GetType());
        }

        public BaseController(IBaseService service,
            ILoggerFactory logger) :this(logger)
        {
            _service = service;
        }

        /// <summary>
        /// Логирует ошибки модели состояния
        /// </summary>
        protected void LogModelStateErrors()
        {
            foreach (var item in ModelState.Values)
            {
                foreach (ModelError error in item.Errors)
                {
                    _logger.LogDebug("ModelState: {0}", error.ErrorMessage);
                }
            }
        }

        protected void LogMethodBegin(object arg = null, [CallerMemberName] string methodName = "")
        {
            _logger.LogDebug($"Call {methodName}. Argument: {arg}. RequestId: {ControllerContext.HttpContext.TraceIdentifier}.");
        }

        protected void LogMethodEnd(object result = null, [CallerMemberName] string methodName = "")
        {
            _logger.LogDebug($"Call {methodName}. Result: {result}. RequestId: {ControllerContext.HttpContext.TraceIdentifier}.");
        }

        protected void LogMethodError(Exception ex, [CallerMemberName] string methodName = "")
        {
            _logger.LogError(ex, $"Call {methodName}. RequestId: {ControllerContext.HttpContext.TraceIdentifier}. Exception: ");
        }
    }
}
