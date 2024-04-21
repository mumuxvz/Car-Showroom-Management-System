using CarModelManagement.Configuration;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.AuthModel;
using CarModelManagement.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace CarModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuthservice _ser;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthservice ser, IConfiguration configuration)
        {
            _ser = ser;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var data = await _ser.Register(model);
            return Ok(data);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var data = await _ser.Login(model);
            var ans = new Jwtmodel {
                token = data
            };
            return Ok(ans);
        }
        [HttpPost]
        [Route("registerCompany-Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var data = await _ser.RegisterAdmin(model);
            return Ok(data);
        }
        [HttpPost]
        [Route("registerSuper-Admin")]
        public async Task<IActionResult> RegisterSuperAdmin([FromBody] RegisterModel model)
        {
            var data = await _ser.RegisterSuperAdmin(model);
            return Ok(data);
        }
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(encryptedText);
                var keyId = token.Header.Kid;
                var audience = token.Audiences.ToList();
                var roleClaim = token.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
                var role = roleClaim?.Value;
                var usernameClaim = token.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
                var username = usernameClaim?.Value;
                //var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
                var data = new DecodedToken(
                        role: role, // Provide the role value here
                        id: token.Id,
                        username:username// Provide the id value here
                      );

                return Ok(data);
            }
            catch (Exception ex)
            {
                // Return error message if decryption fails
                return StatusCode(500, $"Decryption failed: {ex.Message}");
            }
        }
        [HttpPost("checkToken")]
        public IActionResult CheckToken([FromBody]string token)
        {
            if (JwtHelper.IsTokenExpired(token))
            {
                return BadRequest("Token has expired.");
            }

            return Ok("Token is still valid.");
        }
    }
}
