using AssessmentProject.Controllers.DTOs;
using AssessmentProject.Models;

namespace AssessmentProject.Service
{
    public interface IDepartmentService
    {
        public Task<Department> CreateDepartment(Department user);
        public Task DeleteDepartment(Guid departmentId);
        public Task<IEnumerable<Department?>> GetDepartmentsbyPerson(Guid PersonId);
        public Task<IEnumerable<Department?>> GetDepartments();
    }
}
