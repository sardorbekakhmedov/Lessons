using System.Reflection;
using Lesson74Data.Entities;
using System.Runtime.Serialization;

namespace Lesson74Data.DTO;

public class UserDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public EUserRole UserRole { get; set; }
}