using Application.Abstractions;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto register)
        {
            var result = _authService.Register(register);
            var token = _authService.CreateAccessToken(result.Data);
            return Ok(token);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var result = _authService.Login(login);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var token = _authService.CreateAccessToken(result.Data);
            return Ok(token);
        }
        [HttpPost("loginCustomer")]
        public IActionResult LoginCustomer(LoginDto loginCustomer)
        {
            var result = _authService.LoginCustomer(loginCustomer);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("updateUser")]
        public IActionResult Update(UserDto user)
        {
            var result = _authService.Update(user);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
