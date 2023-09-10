using AssessmentProject.Models;

namespace AssessmentProject.Repository;

public interface IPersonRepository
{
    public Task<Person> Add(Person post);
    public Task Delete(Guid id);
    public Task<Person> Update(Person post);
    public Task<Person?> Get(Guid PersonId);
    public Task<IEnumerable<Person>> GetAll();
    public Task<Person?> GetByEmail(string email);
    public Task<Person?> GetByDocument(string document);

}