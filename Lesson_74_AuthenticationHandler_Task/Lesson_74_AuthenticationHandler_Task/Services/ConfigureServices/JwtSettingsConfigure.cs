
namespace Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;

public class JwtSettingsConfigure
{
    public const string SectionName = "JwtSettings";
    public string SecretKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}
