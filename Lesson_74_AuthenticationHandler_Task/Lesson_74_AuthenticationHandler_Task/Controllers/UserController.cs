using System.Security.Claims;
using Lesson_74_AuthenticationHandler_Task.Services;
using Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;
using Lesson74Data.Entities;
using Lesson74Data.Interfaces;
using Lesson74Data.RepositoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lesson_74_AuthenticationHandler_Task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISmallestMultipleFinder _taskFinder;
    private readonly UsersDataPath _options;

    public UserController(IOptions<UsersDataPath> options, ISmallestMultipleFinder taskFinder)
    {
        _taskFinder = taskFinder;
        _options = options.Value;
    }


    [HttpGet("/GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        await UserRepository.ReadUsersDataAsync(_options.FilePath);

        var users = UserRepository.Users;

        return Ok(users);
    }

    [HttpGet("/Profile")]
    [Authorize]
    //[AuthHandler]
    public async Task<IActionResult> Profile()
    {
        await UserRepository.ReadUsersDataAsync(_options.FilePath);

        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var userId = Guid.Parse(userIdString!);

        var user = UserRepository.Users.FirstOrDefault(user => user.Id == userId);

        if (user == null)
            return NotFound();

        return Ok(user);
    }


    [HttpPost("/Task")]
    [Authorize]
    public async Task<IActionResult> Task([FromForm] TaskEntity taskModel)
    {
        var result = _taskFinder.FindSmallestMultiple(taskModel.Number);
        
        return Ok($"Result: {result}");
    }

    [HttpPost("/Secret")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Secret()
    {
        return Ok("Super secret API");
    }
}