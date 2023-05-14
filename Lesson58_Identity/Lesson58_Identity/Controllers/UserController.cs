using Lesson58_Identity.DbContext;
using Lesson58_Identity.DTO;
using Lesson58_Identity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lesson58_Identity.Controllers;

public class UserController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly SignInManager<User> _signInUser;
    private readonly UserManager<User> _userManager;

    public UserController(AppDbContext dbContext, SignInManager<User> signInUser, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _signInUser = signInUser;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SingUp(UserSignUpDTO newUser)
    {
        var checkOut = _dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email || u.UserName == newUser.UserName);

        if (checkOut is not null)
            return Ok("Bunday foydalanuvchi bazada mavjud!");

        
        var user = new User
        {
            UserName = newUser.UserName,
            Email = newUser.Email,
        };

        var result = await _userManager.CreateAsync(user, newUser.Password);

        if (result.Succeeded)
        {
           // await _signInUser.CreateUserPrincipalAsync(user);
            await _signInUser.SignInAsync(user, isPersistent: true);

            return RedirectToAction(nameof(Profile));
        }

        return SignUp();
    }
    
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInDTO user1)
    {
   /*     var userResult = await _signInUser.PasswordSignInAsync(
                                userName: user1.UserName,
                                password: user1.Password, 
                                isPersistent: false,
                                lockoutOnFailure: false);


        if (userResult.Succeeded)
        {
            return RedirectToAction(nameof(Profile));
        }

        return RedirectToAction(nameof(SignIn));
*/
        var checkOut = _dbContext.Users.FirstOrDefault(u => u.Email == user1.Password || u.UserName == user1.UserName);

        if (checkOut == null)
        {
            return RedirectToAction(nameof(Profile));
        }

        return RedirectToAction(nameof(SignIn));
    }


    [Authorize]
    public IActionResult Profile()
    {
        var user1 = HttpContext.User;

        var userId = user1.FindFirstValue(ClaimTypes.NameIdentifier);

        var id = Guid.Parse(userId);

        var user = _dbContext.Users.FirstOrDefault(i => i.Id == id);

        if (user is not null)
        {
            return View(user);
        }
    
        return RedirectToAction("SignUp", "User");
    }

    [HttpGet]
    public IActionResult LogOut()
    {
        return View();
    }

    public bool Isloggined()
    {
        var user = HttpContext.User;

        return user is not null;
    }
}
