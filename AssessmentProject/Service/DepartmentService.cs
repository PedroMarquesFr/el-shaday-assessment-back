using AssessmentProject.Models;
using AssessmentProject.Repository;

namespace AssessmentProject.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPersonRepository _personRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IPersonRepository personRepository)
        {
            _departmentRepository = departmentRepository;
            _personRepository = personRepository;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            var person = await _personRepository.Get(department.PersonId);
            var doesThisDepartmentNameAlreadyExists = await _departmentRepository.GetByName(department.Name);

            if(doesThisDepartmentNameAlreadyExists != null) throw new Exception("Department name already being used");
            if (person == null) throw new Exception("Person doesnt exist.");
            if(person.QualificationId != 3) throw new Exception("Person's qualification is not Colaborator");

            department.CreatedAt = DateTime.UtcNow.ToUniversalTime();
            department.UpdatedAt = DateTime.UtcNow.ToUniversalTime();
            return await _departmentRepository.Add(department);
        }

        public async Task DeleteDepartment(Guid departmentId)
        {
            await _departmentRepository.Delete(departmentId);
        }

        public async Task<IEnumerable<Department?>> GetDepartmentsbyPerson(Guid personId)
        {
            return await _departmentRepository.GetByPerson(personId);
        }

        public async Task<IEnumerable<Department?>> GetDepartments()
        {
            return await _departmentRepository.GetAll();
        }
    }
}
