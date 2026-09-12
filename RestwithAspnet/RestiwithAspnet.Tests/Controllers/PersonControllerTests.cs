using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using RestiwithAspnet.Controllers;
using RestiwithAspnet.Model;
using RestiwithAspnet.Services.Implementations;

namespace RestiwithAspnet.Tests.Controllers;

public class PersonControllerTests
{
    private readonly PersonController _controller = new(NullLogger<PersonController>.Instance, new PersonService());

    [Fact]
    public void Get_ReturnsAllPeople()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Get());
        var people = Assert.IsAssignableFrom<List<Person>>(result.Value);
        Assert.Equal(8, people.Count);
    }

    [Fact]
    public void GetById_ReturnsAPerson()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Get(1L));
        Assert.IsType<Person>(result.Value);
    }

    [Fact]
    public void Post_WithValidPerson_ReturnsCreatedPerson()
    {
        var person = new Person { FirstName = "Ana", LastName = "Silva", Address = "Rua A", Gender = "F" };

        var result = Assert.IsType<OkObjectResult>(_controller.Post(person));

        Assert.Same(person, result.Value);
    }

    [Fact]
    public void Put_WithValidPerson_ReturnsUpdatedPerson()
    {
        var person = new Person { FirstName = "Ana", LastName = "Silva", Address = "Rua A", Gender = "F" };

        var result = Assert.IsType<OkObjectResult>(_controller.Put(person));

        Assert.Same(person, result.Value);
    }

    [Fact]
    public void Delete_ReturnsNoContent()
    {
        Assert.IsType<NoContentResult>(_controller.Delete(1L));
    }
}
