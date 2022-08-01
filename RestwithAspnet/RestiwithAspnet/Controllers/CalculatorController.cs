using Microsoft.AspNetCore.Mvc;

namespace RestiwithAspnet.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "sum/{firtNumber}/{secondNumber}")]
    public IActionResult Get(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input");
    }
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


}
