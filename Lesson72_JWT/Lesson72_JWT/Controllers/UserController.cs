using Identity_Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Lesson72_JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public UserController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet("/GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _appDbContext.Users.ToListAsync();

        return Ok(users);
    }


    [HttpGet("/Profile")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        //var userIdString = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userIdString == null)
        {
            ModelState.AddModelError("Key", "UserId null");
            return BadRequest(ModelState);
        }

        var userId = Guid.Parse(userIdString);

        var user = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);

        if (user == null)
            return NotFound("User not found :(");

        return Ok(user);
    }
}