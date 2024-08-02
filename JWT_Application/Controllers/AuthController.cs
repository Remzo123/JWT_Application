using JWT_Application.DTO.Request;
using JWT_Application.Implementetion.Jwt_Web_Token;
using JWT_Application.Implementetion.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IJWTService _jWTService;
        private readonly IBookingService _bookingService;
        private readonly IConfiguration _configuration;

        public AuthController(IJWTService jWTService, IBookingService bookingService, IConfiguration configuration)
        {
            _jWTService = jWTService;
            _bookingService = bookingService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _bookingService.GetBookingByUserNAmeAsync(request.UserName, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            string tokenResponse = _jWTService.JwtWebToken(user);
            return Ok(new { tokenResponse });






        }
    }
}