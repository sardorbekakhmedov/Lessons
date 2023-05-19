namespace Lesson72_JWT.Services.AppSettingServices;

public class InMemoryAppSettings
{
    public const string SectionName = "ConnectionMemoryString:ConnectionMemory";
    public string Memory { get; set; } = null!;
}