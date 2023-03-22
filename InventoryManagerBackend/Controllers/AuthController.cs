using DataAccess.Models;
using InventoryManagerBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    [EnableCors("allowedOrigin")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.AuthenticateAsync(credentials);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationInfo info)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(info);

            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost("request-password-recovery")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordRecovery(Credentials credentials)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.SendPasswordRecoveryEmailAsync(credentials);

            if (!result.IsEmailSent)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
