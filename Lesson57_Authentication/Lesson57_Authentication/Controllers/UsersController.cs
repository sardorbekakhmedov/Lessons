using System.Security.Claims;
using Lesson57_Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lesson56_Authentication.Controllers;

public class UsersController : Controller
{
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost] 
    public IActionResult SignIn(User user)
    {
        HttpContext context;



        ViewBag.Text = "Success";
        return View();
    }
     
    // [Authorize]
    public string Profile()
    {
        var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);

        return name;
    }

    public string Tickets()
    {
        var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);

        return name + " Tickets null exeption bermediyuuuu ?";
    }
}