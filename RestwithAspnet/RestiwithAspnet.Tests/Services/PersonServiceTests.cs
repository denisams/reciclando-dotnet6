using RestiwithAspnet.Model;
using RestiwithAspnet.Services.Implementations;

namespace RestiwithAspnet.Tests.Services;

public class PersonServiceTests
{
    private readonly PersonService _service = new();

    [Fact]
    public void FindAll_ReturnsEightMockedPeople()
    {
        var people = _service.FindAll();

        Assert.Equal(8, people.Count);
        Assert.All(people, p => Assert.False(string.IsNullOrEmpty(p.FirstName)));
    }

    [Fact]
    public void FindAll_AssignsDistinctIncrementingIds()
    {
        var people = _service.FindAll();

        Assert.Equal(people.Select(p => p.Id).Distinct().Count(), people.Count);
    }

    [Fact]
    public void FindByID_ReturnsAPerson()
    {
        var person = _service.FindByID(1);

        Assert.NotNull(person);
    }

    [Fact]
    public void Create_ReturnsTheSamePersonPassedIn()
    {
        var person = new Person { FirstName = "Ana", LastName = "Silva", Address = "Rua A", Gender = "F" };

        var created = _service.Create(person);

        Assert.Same(person, created);
    }

    [Fact]
    public void Update_ReturnsTheSamePersonPassedIn()
    {
        var person = new Person { FirstName = "Ana", LastName = "Silva", Address = "Rua A", Gender = "F" };

        var updated = _service.Update(person);

        Assert.Same(person, updated);
    }

    [Fact]
    public void Delete_DoesNotThrow()
    {
        var exception = Record.Exception(() => _service.Delete(1));

        Assert.Null(exception);
    }
}
