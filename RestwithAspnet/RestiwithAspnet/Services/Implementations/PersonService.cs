using RestiwithAspnet.Model;

namespace RestiwithAspnet.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {

                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "teste " + i,
                LastName = "teste" + i,
                Address = "teste" + i,
                Gender = "teste" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindByID(long id)
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

        public Person Update(Person person)
        {
            return person;
        }
    }
}
