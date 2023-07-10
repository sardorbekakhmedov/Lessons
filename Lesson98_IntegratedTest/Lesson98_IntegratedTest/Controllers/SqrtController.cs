using Lesson98_IntegratedTest.Models;
using LogicService;
using Microsoft.AspNetCore.Mvc;

namespace Lesson98_IntegratedTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SqrtController : Controller
{
    private readonly ICalculate _calculate;

    public SqrtController(ICalculate calculate)
    {
        _calculate = calculate;
    }

    [HttpPost]
    public IActionResult CalculateSqrt([FromBody] SqrtModel model)
    {
        var result = _calculate.Sqrt(model.Value);

        return Ok(new SqrtResultModel(result));
    }
}