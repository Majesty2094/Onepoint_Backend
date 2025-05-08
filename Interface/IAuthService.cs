using Onepoint_Backend.Dto;

namespace Onepoint_Backend.Services
{
    public interface IAuthService
    {
        Task<bool> SignUpAsync(SignUpDto dto);
        Task<string?> SignInAsync(SignInDto dto);
    }
}

