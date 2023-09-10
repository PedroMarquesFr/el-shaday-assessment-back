using AssessmentProject.Models;

namespace AssessmentProject.Repository
{
    public interface IDepartmentRepository
    {
        public Task<Department> Add(Department department);
        public Task Delete(Guid departmentId);
        public Task<IEnumerable<Department>> GetAll();
        public Task<IEnumerable<Department?>> GetByPerson(Guid personId);
    }
}
