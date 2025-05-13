using Medical.Center.API.Data;
using Medical.Center.API.DTOs;
using Medical.Center.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medical.Center.API.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AuthService(AppDbContext context, IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            //check user exist
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return new AuthResponseDto
                {
                    Message = "Invalid Email or Password"
                };
            }
            //generate token
            var token = GenerateJWTToken(user);

            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JWT:DurationInMinutes"]));

            return new AuthResponseDto
            {
                Token = token,
                Expiration = expiration,
                Message = "Login Successfully"
            };

        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
           if(await _userManager.FindByEmailAsync(registerDto.Email) != null)
            {
                return new AuthResponseDto
                {
                    Message = "Email already exist"
                };
            }

            if (await _userManager.FindByNameAsync(registerDto.UserName) != null)
            {
                return new AuthResponseDto
                {
                    Message = "Username already exist"
                };
            }

            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                Role = "Patient"
            };



            var result = await _userManager.CreateAsync(user, registerDto.Password);


            var token = GenerateJWTToken(user);

            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JWT:DurationInMinutes"]));

            return new AuthResponseDto
            {
                Token = token,
                Expiration = expiration,
                Message = "Registration Successfully"
            };
        }


        private  string GenerateJWTToken(User user)
        {
            // Map IdentityUser to User
            var newUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };

            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
