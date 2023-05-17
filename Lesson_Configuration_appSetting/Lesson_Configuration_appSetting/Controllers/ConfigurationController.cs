using Lesson_Configuration_appSetting.Configuration.ConfigServices;
using Lesson_Configuration_appSetting.Configuration.ConfigurationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lesson_Configuration_appSetting.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly CustomOptions _customOptions;  // Singleton
    private readonly PlayMobile _options;           // Singleton
    //private readonly IOptions<PlayMobile> _options2;   // Singleton

    public ConfigurationController(IConfiguration configuration, CustomOptions options, 
            IOptions<PlayMobile> option,
            IOptionsSnapshot<PlayMobile> optionSnapshot)  // Singleton, custom o'zgartirsa bo'ladi
    {
        _configuration = configuration;
        _customOptions = options;
      //  _options = option.Value;
        _options = optionSnapshot.Value;
    }


    [HttpGet("/GetOptionSection")] // Example 3
    public string GetOptionSection()
    {
       // var playMobile = _configuration.GetSection(PlayMobile.SectionName).Get<PlayMobile>();
        var playMobile = _options;

        return playMobile.BaseUrl + "  Builder_Option";
    }


    [HttpGet("/GetCustomOptionSection")]  // Example 2
    public string GetCustomOptionSection()
    {
        var playMobile = _customOptions.PlayMobile;

        return playMobile.ConfirmPassword + "  Custom_Option";
    }


    [HttpGet]  // Example 1
    public string GetSection()
    {
        var play = _configuration.GetSection(PlayMobile.SectionName)
            .GetSection(Limits.SectionName)
            .Get<Limits>();

        return play.SmsTextLimit1 + "  Section";
    }

}