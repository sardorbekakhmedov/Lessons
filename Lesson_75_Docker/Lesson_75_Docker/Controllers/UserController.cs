using System.Security.Claims;
using Lesson_75_Docker.Context;
using Lesson_75_Docker.Entities;
using Lesson_75_Docker.EntitiesDto;
using Lesson_75_Docker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson_75_Docker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    private readonly JwtServices _jwtServices;

    public UserController(AppDbContext appDbContext, JwtServices jwtServices)
    {
        _appDbContext = appDbContext;
        _jwtServices = jwtServices;
    }

    [HttpPost("/SignUp")]
    public async Task<IActionResult> SignUp([FromForm] UserSignUpDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            Password = model.Password,
            UserRole = model.UserRole.ToString().Normalize(),
            
        };

        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();

        return Ok(user);
    }

    [HttpPost("/SignIn")]
    public async Task<IActionResult> SignIn([FromForm] UserSignInDto model)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(user => user.Password == model.Password);

        if (user == null || user.UserName != model.UserName)
        {
            return BadRequest(ModelState);
        }

        var token = _jwtServices.GetJwtToken(user);

        return Ok(token);
    }

    [HttpGet("/Profile")]
    [Authorize(Policy = "User")]
    public IActionResult Profile()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userIdString == null)
            return BadRequest(ModelState);

        var userId = Guid.Parse(userIdString);

        var user = _appDbContext.Users.FirstOrDefault(user => user.Id == userId);

        return Ok(user);
    }


    [HttpGet("/Admin")]
    [Authorize(Policy = "Admin")]
    public IActionResult Admin()
    {

        return Ok(new
        {
            Role = "Admin",
            Name = "James Don",
            Age = 30
        });
    }

}