using Lesson70_Mapping.Models;

namespace Lesson70_Mapping.DTO;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
}