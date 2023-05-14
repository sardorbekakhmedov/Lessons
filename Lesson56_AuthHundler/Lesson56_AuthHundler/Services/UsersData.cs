namespace Lesson56_AuthorHundler.Services;


public class UsersData
{
    public List<User> Users = new ();

    private static UsersData? _instance;
    public static UsersData Instance => _instance ??= new ();
}


public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}