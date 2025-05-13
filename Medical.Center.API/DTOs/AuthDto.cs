using System.ComponentModel.DataAnnotations;

namespace Medical.Center.API.DTOs
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponseDto
    {

        public string Token { get; set; }
        public string  Message{ get; set; }
        public DateTime Expiration { get; set; }
    }
}
