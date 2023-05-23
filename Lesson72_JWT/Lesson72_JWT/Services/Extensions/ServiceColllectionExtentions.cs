using System.Text;
using Lesson72_JWT.Services.JwtServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Lesson72_JWT.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddJwtConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("JWTSettings:SecretKey").Value;
        var issuer = configuration.GetSection("JwtSettings:Issuer").Value;
        var audience = configuration.GetSection("JwtSettings:Audience").Value;

        var signinKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(secretKey!));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                IssuerSigningKey = signinKey,
                ValidateIssuerSigningKey = true,
                //  ClockSkew = TimeSpan.Zero,
                LifetimeValidator = CustomLifeTime.CustomLifeTimeValidator


                /*   ValidIssuer = "Identity.Api",  // Kim tomonidan
                   ValidAudience = "Products",   // kimlar uchun
                 //  ValidAudiences = 
                   ValidateIssuer = true,  // Qaytgan Tokenni tekshirsinmi
                   ValidateAudience = true,   // Qaytgan Tokenni tekshirsinmi
                   IssuerSigningKey = signinKey,
                   RequireExpirationTime = true,
                   ValidateIssuerSigningKey = true   ,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero*/
            };
        });
    }
}