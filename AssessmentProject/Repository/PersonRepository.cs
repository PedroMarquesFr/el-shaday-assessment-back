using AssessmentProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Repository;
public class PersonRepository : IPersonRepository
{
    protected readonly ApplicationDbContext _context;
    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Person> Add(Person person)
    {
        _context.Add(person);

        await _context.SaveChangesAsync();
        return person;
    }
    public async Task Delete(Guid id)
    {

        var result = _context.Person.Include(e => e.Departments).Single(p => p.Id == id);
        _context.Remove(result);

        await _context.SaveChangesAsync();
    }

    public async Task<Person> Update(Person person)
    {
        //_context.ChangeTracker.Clear(); // observaar funcionamento
        _context.Update(person);

        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> Get(Guid PersonId)
    {
        var user = await _context.Person.AsNoTracking().FirstOrDefaultAsync(a => a.Id == PersonId);
        return user;
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        var users = await _context.Person.ToListAsync();

        return users;
    }

    public async Task<Person?> GetByEmail(string email)
    {
        var user = await _context.Person.AsNoTracking().FirstOrDefaultAsync(a => a.Email == email);
        return user;
    }

}