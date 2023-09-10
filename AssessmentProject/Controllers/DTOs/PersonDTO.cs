using AssessmentProject.Controllers.Shared;
using System.ComponentModel.DataAnnotations;

namespace AssessmentProject.Controllers.DTOs
{
    public class PersonDto
    {
        [Required]
        public EPersonType PersonType { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Apelido { get; set; }
        [Required]
        public string EnderecoCadastro { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public EQualification Qualification { get; set; }
        [Required]
        public ERoles Role { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsActivated { get; set; }
    }
}
