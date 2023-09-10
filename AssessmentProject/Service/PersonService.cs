using AssessmentProject.Controllers.DTOs;
using AssessmentProject.Models;
using AssessmentProject.Repository;

namespace AssessmentProject.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IJwtProvider _jwtProvider;

        public PersonService(IPersonRepository personRepository, IJwtProvider jwtProvider)
        {
            _personRepository = personRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Person> CreatePerson(PersonDto user)
        {
            if (user == null) throw new Exception("Person not defined.");

            var isEmailRegistered = await _personRepository.GetByEmail(user.Email);
            var isDocumentRegistered = await _personRepository.GetByDocument(user.Document);

            if (isEmailRegistered != null) throw new Exception("Person's Email already registered.");
            if (isDocumentRegistered != null) throw new Exception("Person's Document already registered.");

            var personEntity = new Person
            {
                Id = new Guid(),
                Email = user.Email,
                Name = user.Nome,
                Password = user.Password,
                Document = user.Document,
                Apelido = user.Apelido,
                TypeId = (int)user.PersonType,
                RoleId = (int)user.Role,
                QualificationId = (int)user.Qualification,
                PersonAddress = user.EnderecoCadastro,
                IsActivated = true,
                CreatedAt = DateTime.UtcNow.ToUniversalTime(),
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
            };
            return await _personRepository.Add(personEntity);
        }

        public async Task DeactivatePerson(Guid id)
        {

            var existingPerson = await _personRepository.Get(id);

            if (existingPerson == null) throw new Exception("Person doesn't exists.");

            existingPerson.IsActivated = false;

            await _personRepository.Update(existingPerson);
            return;
        }
        public async Task ActivatePerson(Guid id)
        {

            var existingPerson = await _personRepository.Get(id);

            if (existingPerson == null) throw new Exception("Person doesn't exists.");

            existingPerson.IsActivated = true;

            await _personRepository.Update(existingPerson);
            return;
        }

        public async Task<Person> UpdatePerson(PersonWithIdDto person)
        {
            if (person == null) throw new Exception("Person not defined.");
            if (person?.Id == null) throw new Exception("Id not Passed.");

            var existingPerson = await _personRepository.Get(person.Id);

            if (existingPerson == null) throw new Exception("Person doenst exist.");

            existingPerson.IsActivated = false;

            var personEntity = new Person
            {
                Id = person.Id,
                Email = person.Email,
                Name = person.Nome,
                Password = person.Password,
                Document = person.Document,
                Apelido = person.Apelido,
                TypeId = (int)person.PersonType,
                RoleId = (int)person.Role,
                QualificationId = (int)person.Qualification,
                PersonAddress = person.EnderecoCadastro,
                IsActivated = person.IsActivated,
                CreatedAt = existingPerson.CreatedAt,
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
            };

            var newPerson = await _personRepository.Update(personEntity);
            return newPerson;
        }

        public async Task<Person?> GetPerson(Guid PersonId)
        {
            var person = await _personRepository.Get(PersonId);
            if (person == null) throw new Exception("Person not found");
            return person;
        }

        public async Task<IEnumerable<Person?>> GetPersons()
        {
            return await _personRepository.GetAll();
        }

        public async Task<string> Authenticate(LoginRequestDTO loginData)
        {
            var person = await _personRepository.GetByEmail(loginData.Email);
            if(person == null) throw new Exception("Person not Registered.");
            if (!person.IsActivated) throw new Exception("Person not Activated.");
            if (person.Password != loginData.Password) throw new Exception("Incorrect password.");

            return _jwtProvider.Generate(person);
        }
    }
}
