namespace Lesson_Configuration_appSetting.Configuration.ConfigurationModels;

public class Limits
{
    public const string SectionName = "Limits";
    public string SmsTextLimit1 { get; set; } = null!;
    public string SmsTextLimit2 { get; set; } = null!;
    public string SmsTextLimit3 { get; set; } = null!;
    public string[] SmsTextLimits { get; set; } = null!;
}