using Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;
using Lesson74Data.DTO;
using Lesson74Data.Entities;
using Lesson74Data.Interfaces;
using Lesson74Data.RepositoryServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lesson_74_AuthenticationHandler_Task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IJwtTokenServices _jwtToken;
    private readonly UsersDataPath _options;

    public AccountController(IOptions<UsersDataPath> options, 
        IJwtTokenServices jwtToken)
    {
        _jwtToken = jwtToken;
        _options = options.Value;
    }


    [HttpPost("/SignUp")]
    public async Task<IActionResult> SignUp([FromForm] UserDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User()
        {
            Id = Guid.NewGuid(),
            Email = model.Email,
            Password = model.Password,
            UserName = model.UserName,
        };
    

        switch ((int)model.UserRole)
        {
            case 0:
                user.UserRoles.Add(new UserRole() { Id = Guid.NewGuid(), Name = "Admin" });
                break;
            case 1:
                user.UserRoles.Add(new UserRole() { Id = Guid.NewGuid(), Name = "User" });
                break;
            case 2:
                user.UserRoles.Add(new UserRole() { Id = Guid.NewGuid(), Name = "Teacher" });
                break;
            case 3:
                user.UserRoles.Add(new UserRole() { Id = Guid.NewGuid(), Name = "Student" });
                break;
        }


        UserRepository.Users.Add(user);

        await UserRepository.SaveUsersAsync(_options.FilePath);

        return Ok(user);
    }

    [HttpPost("/Login")]
    public async Task<IActionResult> Login([FromForm] UserLoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await UserRepository.ReadUsersDataAsync(_options.FilePath);

        var user = UserRepository.Users.FirstOrDefault(user => user.UserName == model.UserName);

        if (user == null || user.Password != model.Password)
        {
            ModelState.AddModelError("", "User not found");
            return NotFound(ModelState);
        }

        var token = _jwtToken.CreateJwtToken(user);

        return Ok(token);
    }

}