using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity_Data.Entities;
using Lesson72_JWT.Services.AppSettingServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lesson72_JWT.Services.JwtServices;

public class CreateJwtToken
{
    private readonly JwtSettings _jwtOptions;

    public CreateJwtToken(IOptions<JwtSettings> options)
    {
        _jwtOptions = options.Value;
    }

    public string GetJwtToken(User user)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Email, user.Email ?? "noemail@gmail.com")
        };

        var secretKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_jwtOptions.SecretKey));

        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
            signingCredentials: credentials
        );

        var newTokenJwt = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return newTokenJwt;
    }
}