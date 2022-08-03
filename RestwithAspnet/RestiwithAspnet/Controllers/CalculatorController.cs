using Microsoft.AspNetCore.Mvc;

namespace RestiwithAspnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }


    #region ----------- Private ----------------------
    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber,
                                        System.Globalization.NumberStyles.Any,
                                        System.Globalization.NumberFormatInfo.InvariantInfo,
                                        out number);

        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }
    #endregion

    [HttpGet("sum/{fistNumber}/{secondNumber}")]
    public IActionResult Sum(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var result = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);
            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Subtraction/{fistNumber}/{secondNumber}")]
    public IActionResult Subtraction(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var result = ConvertToDecimal(fistNumber) - ConvertToDecimal(secondNumber);
            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiply/{fistNumber}/{secondNumber}")]
    public IActionResult Multiply(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var result = ConvertToDecimal(fistNumber) * ConvertToDecimal(secondNumber);
            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Division/{fistNumber}/{secondNumber}")]
    public IActionResult Division(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var result = ConvertToDecimal(fistNumber) / ConvertToDecimal(secondNumber);
            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Mean/{fistNumber}/{secondNumber}")]
    public IActionResult Mean(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var result = (ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Square/{fistNumber}")]
    public IActionResult Square(string fistNumber)
    {
        if (IsNumeric(fistNumber))
        {
            var result = Math.Sqrt((double)ConvertToDecimal(fistNumber));
            return Ok(result.ToString());
        }

        return BadRequest("Invalid Input");
    }


}
