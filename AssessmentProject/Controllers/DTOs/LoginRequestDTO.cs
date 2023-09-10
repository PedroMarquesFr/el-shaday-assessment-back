using System.ComponentModel.DataAnnotations;

namespace AssessmentProject.Controllers.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        public string Email { get; }
        [Required]
        public string Password { get; }

        public LoginRequestDTO(
            string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
