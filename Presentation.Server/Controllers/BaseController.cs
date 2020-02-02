using Microsoft.AspNetCore.Mvc;
using UnderTheBrand.Domain.Model.Utils;
using UnderTheBrand.Domain.Model.Values;

namespace UnderTheBrand.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected BaseController() { }
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
