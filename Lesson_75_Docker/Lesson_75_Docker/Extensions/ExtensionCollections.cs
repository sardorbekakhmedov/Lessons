using System.Data.SqlTypes;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lesson_75_Docker.Extensions;

public static class ExtensionCollections
{
    public static void AddJwtTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("JwtSettings:SecretKey").Value;
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
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = signinKey,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = CustomLifeTime.CustomLifeTimeValidator
            };
        });
    }

    public static void AddSwaggerWithBearer(this IServiceCollection services)
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

    public static void AddCustomPolicyRoles(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", builder1 =>
            {
                builder1.RequireClaim(ClaimTypes.Role, "Admin");
            });

            options.AddPolicy("User", builder2 =>
            {
                builder2.RequireAssertion(handler =>
                    handler.User.HasClaim(ClaimTypes.Role, "User")
                    || handler.User.HasClaim(ClaimTypes.Role, "Admin"));
            });
        });
    }
}