namespace Lesson_75_Docker.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string UserRole { get; set; } = null!;
}