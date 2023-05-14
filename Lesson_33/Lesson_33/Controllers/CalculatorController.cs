using Microsoft.AspNetCore.Mvc;

namespace Lesson_33.Controllers;

[Route("/calculator")]
[ApiController]
public class CalculatorController : ControllerBase
{
    [Route("")]
    public string Default() => "Default function";

    [Route("add1")]
    public string Add() => "A + B = C";

    [Route("sub")]
    public string Sub() => "A - B = CC";

    [Route("phone")]
    public string Phone() => "Phone function";

    [Route("phones{name}")]
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

}
