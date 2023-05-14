using Microsoft.AspNetCore.Mvc;

namespace Lesson_33.Controllers;

// [Route("[controller]/[action]")]
[Route("[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{

    [Route("add")]
    [Route("sum")]
    [Route("add/{a}/{b}")]
    [Route("sum/{a}/{b}")]
    public string Add(int a, int b, int c) => $"Result:  a: {a} + b: {b} + c: {c} = {a + b + c}";

}
