using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace RestiwithAspnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController(ILogger<CalculatorController> logger) : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger = logger;

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            return BadRequest("Invalid Input");

        var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }

    [HttpGet("Subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            return BadRequest("Invalid Input");

        var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }

    [HttpGet("multiply/{firstNumber}/{secondNumber}")]
    public IActionResult Multiply(string firstNumber, string secondNumber)
    {
        if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            return BadRequest("Invalid Input");

        var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }

    [HttpGet("Division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            return BadRequest("Invalid Input");

        var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }

    [HttpGet("Mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber)
    {
        if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            return BadRequest("Invalid Input");

        var result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }

    [HttpGet("Square/{firstNumber}")]
    public IActionResult Square(string firstNumber)
    {
        if (!IsNumeric(firstNumber))
            return BadRequest("Invalid Input");

        var result = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }

    private static bool IsNumeric(string strNumber) =>
        double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out _);

    private static decimal ConvertToDecimal(string strNumber) =>
        decimal.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out var decimalValue)
            ? decimalValue
            : 0;
}
