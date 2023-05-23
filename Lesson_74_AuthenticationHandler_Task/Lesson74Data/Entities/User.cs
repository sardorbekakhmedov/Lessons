namespace Lesson74Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<UserRole> UserRoles { get; set; }

    public User()
    {
        UserRoles = new List<UserRole>();
    }
}