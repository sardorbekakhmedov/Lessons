using Lesson58_Identity.DbContext;
using Lesson58_Identity.DTO;
using Lesson58_Identity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lesson58_Identity.Controllers;

public class ResultController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly SignInManager<User> _signInUser;
    private readonly UserManager<User> _userManager;

    public ResultController(AppDbContext dbContext, SignInManager<User> signInUser, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _signInUser = signInUser;
        _userManager = userManager;
    }

    public IActionResult Calculate()
    {
        return View();
    }

    [Authorize]
    public IActionResult Result(ResultDTO result)
    {
        int num1 = result.Num1;
        int num2 = result.Num2;
        int countResult = 0;

        for (int i = 1; i <= num2; i++)
        {
            string s = i.ToString();
            int digitCount = s.Count(c => c == num1.ToString()[0]);
            countResult += digitCount;
        }

        var result1 = new Result()
        {
            Num1 = num1,
            Num2 = num2,
            Output = countResult
        };

        var user1 = HttpContext.User;

        var userId = user1.FindFirstValue(ClaimTypes.NameIdentifier);

        var id = Guid.Parse(userId);

        var user = _dbContext.Users.FirstOrDefault(i => i.Id == id);

        if (user is not null)
        {
            user.Results.Add(result);
        }
        else
        {
            return RedirectToAction("SignUp", "User");
        }

        _dbContext.SaveChanges();

        return View(result1);
    }
}