using Medical.Center.API.DTOs;
using Medical.Center.API.Service.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medical.Center.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Authentication endpoints")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);

            if (result == null)
                return Unauthorized(result);

            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody]RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
