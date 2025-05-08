using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Onepoint_Backend.Data;
using Onepoint_Backend.Dto;
using Onepoint_Backend.Models;

namespace Onepoint_Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config  = config;
        }

        public async Task<bool> SignUpAsync(SignUpDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return false;

            var salt = Encoding.UTF8.GetBytes(dto.Email);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: dto.Password,
                salt:     salt,
                prf:      KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            var user = new User {
                EmployeeID   = dto.EmployeeID,
                Email        = dto.Email,
                FullName     = dto.FullName,
                PhoneNumber  = dto.PhoneNumber,
                PasswordHash = hash,
                Role         = "User",
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> SignInAsync(SignInDto dto)
        {
            var user = await _context.Users
                         .FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return null;

            var hashedInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: dto.Password,
                salt:    Encoding.UTF8.GetBytes(user.Email),
                prf:     KeyDerivationPrf.HMACSHA256,
                iterationCount:10000,
                numBytesRequested:256/8));
            if (hashedInput != user.PasswordHash)
                return null;

        

            var key    = Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]!);
            var creds  = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email,         user.Email),
                new Claim(ClaimTypes.Role,          user.Role)
            };
            var token = new JwtSecurityToken(
                issuer:   _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims:   claims,
                expires:  DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
