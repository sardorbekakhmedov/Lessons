namespace Lesson72_JWT.Services.AppSettingServices;

public class DataBaseAppSettings
{
    public const string SectionName = "ConnectionString:Connection";

    public string Connection { get; set; } = null!;
}