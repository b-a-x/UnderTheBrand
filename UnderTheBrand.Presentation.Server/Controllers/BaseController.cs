using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using UnderTheBrand.Domain.Core.Entities;
using UnderTheBrand.Domain.Core.Values;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Presentation.Server.Controllers.Interfaces;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller, IBaseController
    {
        private readonly IBaseService _service;
        private readonly IPersonProvider _provider;
        private readonly ILogger<BaseController> _logger;

        public BaseController(IBaseService service, 
                              IPersonProvider provider, 
                              ILogger<BaseController> logger)
        {
            _service = service;
            _provider = provider;
            _logger = logger;
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get()
        {
            try
            {
                LogMethodBegin();

                Name name = new Name("Ilia");
                _provider.Create(new Person(new PersonalName(name, name), new Age(28)));
                IReadOnlyCollection<Person> persons = _provider.Read();

                LogMethodEnd(persons);
                
                return Ok(persons);
            }
            catch (Exception e)
            {
                LogMethodError(e);
                throw;
            }
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
