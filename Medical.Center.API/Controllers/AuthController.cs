using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medical.Center.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Authentication and user management endpoints")]
    public class AuthController : ControllerBase
    {

        [HttpGet("status")]
        [SwaggerOperation(
            Summary = "Check API Status",
            Description = "Verifies that the API is operational",
            OperationId = "Auth.Status",
            Tags = new[] { "Health" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "API is working correctly", typeof(string))]
        public IActionResult GetStatus()
        {
            return Ok("API is working");
        }
    }
}
