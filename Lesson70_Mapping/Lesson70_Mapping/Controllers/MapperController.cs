using Lesson70_Mapping.DTO;
using Lesson70_Mapping.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Lesson70_Mapping.Controllers;

[ApiController]
[Route("[controller]")]
public class MapperController : Controller
{
    [HttpGet]
    public IActionResult GetProduct()
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Email = "mappar@gmail.com",
            Name = "MapTo",
            Password = "password123",
            UserName = "username"
        };

        var userDto = user.Adapt<UserDto>();

        return Ok(userDto);
    }
}