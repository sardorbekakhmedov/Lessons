namespace Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;

public class UsersDataPath
{
    public const string SectionName = "UsersDataFilePath";
    public string FilePath { get; set; } = null!;
}