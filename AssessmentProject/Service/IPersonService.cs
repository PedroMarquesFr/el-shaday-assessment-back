using AssessmentProject.Controllers.DTOs;
using AssessmentProject.Models;

namespace AssessmentProject.Service
{
    public interface IPersonService
    {
        public Task<Person> CreatePerson(PersonDto user);
        public Task DeactivatePerson(Guid id);
        public Task<Person> UpdatePerson(PersonWithIdDto user);
        public Task<Person?> GetPerson(Guid PersonId);
        public Task<IEnumerable<Person?>> GetPersons();
        public Task<string> Authenticate(LoginRequestDTO loginData);
        //   public IEnumerable<Person> GetAll();
    }
}
