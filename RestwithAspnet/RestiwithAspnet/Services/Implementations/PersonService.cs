using RestiwithAspnet.Model;

namespace RestiwithAspnet.Services.Implementations;

public class PersonService : IPersonService
{
    private int count;

    public Person Create(Person person) => person;

    public void Delete(long id)
    {
    }

    public List<Person> FindAll()
    {
        List<Person> persons = [];
        for (int i = 0; i < 8; i++)
        {
            persons.Add(MockPerson(i));
        }
        return persons;
    }

    public Person? FindByID(long id)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = "teste",
            LastName = "teste",
            Address = "teste",
            Gender = "teste"
        };
    }

    public Person Update(Person person) => person;

    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = $"teste {i}",
            LastName = $"teste{i}",
            Address = $"teste{i}",
            Gender = $"teste{i}"
        };
    }

    private long IncrementAndGet() => Interlocked.Increment(ref count);
}
