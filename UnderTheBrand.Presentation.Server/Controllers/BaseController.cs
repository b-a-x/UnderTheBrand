using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
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
            // TODO: Нужно логировать запросы в middleware
            _logger = logger.CreateLogger(GetType());
        }

        public BaseController(IBaseService service,
            ILoggerFactory logger) :this(logger)
        {
            _service = service;
        }

        // TODO: Нужно логировать запросы в middleware
        protected void LogMethodBegin(object arg = null, [CallerMemberName] string methodName = "")
        {
            _logger.LogDebug($"Call {methodName}. Argument: {arg}. RequestId: {ControllerContext.HttpContext.TraceIdentifier}.");
        }

        // TODO: Нужно логировать запросы в middleware
        protected void LogMethodEnd(object result = null, [CallerMemberName] string methodName = "")
        {
            _logger.LogDebug($"Call {methodName}. Result: {result}. RequestId: {ControllerContext.HttpContext.TraceIdentifier}.");
        }
    }
}
