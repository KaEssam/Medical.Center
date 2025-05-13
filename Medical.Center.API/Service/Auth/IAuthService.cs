using Medical.Center.API.DTOs;

namespace Medical.Center.API.Service.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Login(LoginDto loginDto);

        Task<AuthResponseDto> Register(RegisterDto registerDto);
    }
}
