using RestiwithAspnet.Model;

namespace RestiwithAspnet.Services;

public interface IPersonService
{
    Person Create(Person person);
    Person Update(Person person);
    void Delete(long id);
    List<Person> FindAll();
    Person? FindByID(long id);
}
