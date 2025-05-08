using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Onepoint_Backend.Data;
using Onepoint_Backend.Models;
using Onepoint_Backend.Dto;
using Onepoint_Backend.Services;

namespace Onepoint_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _auth.SignUpAsync(dto);
            return created 
                ? Ok(new { message = "Registration successful." }) 
                : Conflict(new { message = "Registration Unsuccessful." });
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _auth.SignInAsync(dto);
            return token != null 
                ? Ok(new { token }) 
                : Unauthorized(new { message = "Invalid credentials." });
        }
    }
}