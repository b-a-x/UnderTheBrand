using Microsoft.AspNetCore.Mvc;
using UnderTheBrand.Domain.ValueObject.Helpers;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Presentation.Server.Controllers.Interfaces;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase, IBaseController
    {
        private readonly IBaseService _service;
        protected BaseController() { }
        
        public BaseController(IBaseService service) 
        {
            _service = service;
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
