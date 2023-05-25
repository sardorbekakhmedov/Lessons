using System.Runtime.Serialization;
using Lesson_75_Docker.Entities;

namespace Lesson_75_Docker.EntitiesDto;

public class UserSignUpDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public EUserRole UserRole { get; set; }
}