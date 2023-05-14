using Microsoft.AspNetCore.Mvc;

namespace Lesson_34.Controllers;

public class MyController : Controller
{
    public IActionResult Sum(int a, int b)
    {
        ViewBag.a = a;
        ViewBag.b = b;
        ViewBag.Sum = a + b;

        return View();
    }

    public IActionResult Sub(int a, int b)
    {
        ViewBag.a = a;
        ViewBag.b = b;
        ViewBag.Sum = a - b;

        return View();
    }

    public IActionResult Question() => View();

}
