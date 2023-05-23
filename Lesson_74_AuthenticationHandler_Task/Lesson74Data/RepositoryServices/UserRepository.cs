using Lesson74Data.Entities;
using Newtonsoft.Json;

namespace Lesson74Data.RepositoryServices;

public static class UserRepository
{
    public static List<User> Users { get; set; } = new ();

    public static async Task SaveUsersAsync(string filePath)
    {
        var textContent = JsonConvert.SerializeObject(Users);
        await File.WriteAllTextAsync(filePath, textContent);
    }

    public static async Task ReadUsersDataAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonText = await File.ReadAllTextAsync(filePath);
            Users = JsonConvert.DeserializeObject<List<User>>(jsonText)!;
        }
    }

    public static async Task<User?> GetUserByIdAsync(Guid userId, string filePath)
    {
        await ReadUsersDataAsync(filePath);

        var user = Users.FirstOrDefault(user => user.Id == userId);

        return user ?? null;
    }
}