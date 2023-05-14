using System.Security.Claims;
using Lesson56_AuthorHundler.ActionFilters;
using Lesson56_AuthorHundler.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson56_AuthorHundler.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public string SignIn(string userName)
    {
        if (userName != "")
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userName,
            };

            UsersData.Instance.Users.Add(user);

            HttpContext.Response.Cookies.Append("user_Id", user.Id.ToString() );

            return $"New username:   {user.Name}";
        }

        return "not user name";
    }

    [UserLoginValidate]
    public string Profile()
    {
        var user = HttpContext.User;

        // var name = HttpContext.User.Claims.First(t => t.Type == "Name").Value;
        // var name = HttpContext.User.FindFirst("Name");

        var userId = user.FindFirstValue("UserId");
        var name = user.FindFirstValue("UserName");

        return $"Username:  {name},  UserId:  {userId}";
    }


    [UserLoginValidate]
    public string Tickets()
    {
        var user = HttpContext.User;

        return "Name not found, not is login";
    }

    public User? IsLogin()
    {
        if (HttpContext.Request.Cookies.ContainsKey("user_id"))
        {
            var cookieUserId = HttpContext.Request.Cookies["user_id"];

            if (cookieUserId != null)
            {
                var userId = Guid.Parse(cookieUserId);
                
                if (UsersData.Instance.Users.Any(i => i.Id == userId))
                {
                    var user = UsersData.Instance.Users.FirstOrDefault(u => u.Id == userId);

                    return user;
                }
            }
        }
        return null;
    }
}