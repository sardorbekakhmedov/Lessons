using Identity_Data.Context;
using Identity_Data.DTO;
using Identity_Data.Entities;
using Lesson72_JWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson72_JWT.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly AppDbContext _appDbContext;
    private readonly CreateJwtToken _jwtToken;

    public AccountController(AppDbContext dbContext, CreateJwtToken jwtToken )
    {
        _appDbContext = dbContext;
        _jwtToken = jwtToken;
    }

    [HttpPost("/SignUp")]
    public IActionResult SignUp([FromForm] UserDto modelDto )
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("Key", errorMessage: "Model data invalid");
            return BadRequest(ModelState);
        }

        var user = new User
        {
            FirstName = modelDto.FirstName,
            Email = modelDto.Email,
            UserName = modelDto.UserName,
            Password = modelDto.Password,
            ConfirmPassword = modelDto.ConfirmPassword
        };

        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();

        return Ok(user);
    }

    [HttpPost ("/Login")]
    public IActionResult Login([FromForm] UserLoginDto modelDto)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("Key", "Invalid model data :(");
            return BadRequest(ModelState);
        }

        var user = _appDbContext.Users.FirstOrDefault(user => user.UserName == modelDto.UserName);

        if (user == null || user.Password != modelDto.Password)
        {
            return NotFound();
        }

        var token = _jwtToken.GetJwtToken(user);

        return Ok(token);
    }
}