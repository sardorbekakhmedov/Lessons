using Lesson_Configuration_appSetting.Configuration.ConfigurationModels;

namespace Lesson_Configuration_appSetting.Configuration.ConfigServices;

public class CustomOptions
{
    public PlayMobile PlayMobile { get; set; }

    public CustomOptions(IConfiguration configuration)
    {
        PlayMobile = configuration.GetSection(PlayMobile.SectionName).Get<PlayMobile>();
    }
}