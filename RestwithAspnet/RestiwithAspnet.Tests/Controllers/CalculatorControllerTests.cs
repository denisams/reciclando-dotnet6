using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using RestiwithAspnet.Controllers;

namespace RestiwithAspnet.Tests.Controllers;

public class CalculatorControllerTests
{
    private readonly CalculatorController _controller = new(NullLogger<CalculatorController>.Instance);

    [Theory]
    [InlineData("2", "3", "5")]
    [InlineData("-2", "3", "1")]
    [InlineData("2.5", "2.5", "5.0")]
    public void Sum_WithValidNumbers_ReturnsSum(string first, string second, string expected)
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Sum(first, second));
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void Sum_WithNonNumericInput_ReturnsBadRequest()
    {
        Assert.IsType<BadRequestObjectResult>(_controller.Sum("abc", "3"));
    }

    [Fact]
    public void Subtraction_WithValidNumbers_ReturnsDifference()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Subtraction("5", "3"));
        Assert.Equal("2", result.Value);
    }

    [Fact]
    public void Multiply_WithValidNumbers_ReturnsProduct()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Multiply("4", "3"));
        Assert.Equal("12", result.Value);
    }

    [Fact]
    public void Division_WithValidNumbers_ReturnsQuotient()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Division("10", "2"));
        Assert.Equal("5", result.Value);
    }

    [Fact]
    public void Division_WithNonNumericInput_ReturnsBadRequest()
    {
        Assert.IsType<BadRequestObjectResult>(_controller.Division("10", "x"));
    }

    [Fact]
    public void Mean_WithValidNumbers_ReturnsAverage()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Mean("4", "6"));
        Assert.Equal("5", result.Value);
    }

    [Fact]
    public void Square_WithValidNumber_ReturnsSquareRoot()
    {
        var result = Assert.IsType<OkObjectResult>(_controller.Square("9"));
        Assert.Equal("3", result.Value);
    }

    [Fact]
    public void Square_WithNonNumericInput_ReturnsBadRequest()
    {
        Assert.IsType<BadRequestObjectResult>(_controller.Square("abc"));
    }
}
