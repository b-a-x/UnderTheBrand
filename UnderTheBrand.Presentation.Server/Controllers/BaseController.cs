using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.ValueObject.Helpers;
using UnderTheBrand.Domain.ValueObject.Values;
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

        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult FromResult(Result result)
        {
            if (result.Success)
                return Ok();

            if (result.Error == Errors.General.NotFound())
                return NotFound(Envelope.Error(""));
            //return NotFound(Envelope.Error(result.Error));

            //return BadRequest(Envelope.Error(result.Error));
            return BadRequest(Envelope.Error(""));
        }
    }
}
