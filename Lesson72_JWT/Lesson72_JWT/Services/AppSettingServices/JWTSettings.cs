namespace Lesson72_JWT.Services.AppSettingServices;

public class JwtSettings
{
    public const string SectionName = "JWTSettings";

    public string SecretKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}