using Microsoft.AspNetCore.Mvc;

namespace Lesson_33.Controllers;

[Route("/parametr")]
[ApiController]
public class ParamentrController : ControllerBase
{
    [Route("")]
    public string Default() => "Default parametr function";


    [Route("phones/{name}")]
    public string Phones(string name)
    {
        if (name == "samsung")
            return "A51, A73, Galaxy 23 ultra";

        else if (name == "apple")
            return "X10, X11 pro, x15";

        else if (name == "redmi")
            return "X19, X71 loock, psa";

        return "not found error 404";
    }


    [Route("sum/{a}/and/{b}")]
    [Route("sum/{a}/{b}")]
    public string Sum(int a, int b)
    {
        return $"result: {a} + {b} = {a + b}";
    }


    [Route("sum2")]
    public string Sum2(int a, int b, int c)
    {
        return $"result: {a} + {b} + {c} = {a + b + c}";
    }
}
