using System.ComponentModel.DataAnnotations;

namespace AssessmentProject.Controllers.DTOs
{
    public class DepartmentDto
    {
        [Required]
        public Guid PersonId { get; }
        [Required]
        public string Name { get; }

        public DepartmentDto(
            Guid personId, string name)
        {
            PersonId = personId;
            Name = name;
        }
    }
}
