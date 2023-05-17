namespace Lesson_Configuration_appSetting.Configuration.ConfigurationModels;

public class PlayMobile
{
    public const string SectionName = "PlayMobile";

    public string BaseUrl { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    public Limits Limits { get; set; } = null!;
}