using System.Text;
using Lesson_74_AuthenticationHandler_Task.Services.AuthHandlerServices;
using Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lesson_74_AuthenticationHandler_Task.Extensions;

public static class ExtensionCollections
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("JwtSettings:SecretKey").Value;
        var issuer = configuration.GetSection("JwtSettings:Issuer").Value;
        var audience = configuration.GetSection("JwtSettings:Audience").Value;


        var signInKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(secretKey!));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = signInKey,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                LifetimeValidator = CustomLifeTime.CustomLifeTimeValidator
            };
        });
        //.AddScheme<JwtAuthenticationOptions, JwtAuthenticationHandler>("JwtScheme", options => { });

    }

    public static void AddSwaggerGenWithToken(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "api",
                Version = "v1",
                Description = "Api for",
                TermsOfService = new Uri("https://localhost:7235")
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = @"JWT Bearer. : \Authorization: Bearer {token}\",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },

                    new List<string>(){}
                }
            });
        });
    }

}