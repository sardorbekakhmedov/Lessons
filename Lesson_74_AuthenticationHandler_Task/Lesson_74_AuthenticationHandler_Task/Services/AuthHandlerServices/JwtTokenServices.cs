using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;
using Lesson74Data.Entities;
using Lesson74Data.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lesson_74_AuthenticationHandler_Task.Services.AuthHandlerServices;

public class JwtTokenServices : IJwtTokenServices
{
    private readonly JwtSettingsConfigure _jwtOptions;

    public JwtTokenServices(IOptions<JwtSettingsConfigure> options)
    {
        _jwtOptions = options.Value;
    }

    public string CreateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
        };

        foreach (var role in user.UserRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_jwtOptions.SecretKey));

        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var utcNow = DateTime.UtcNow;

        var jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            signingCredentials: signInCredentials,
            notBefore: utcNow,
            expires: utcNow.AddMinutes(3)
        );

        var jwtTokenHandler = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return jwtTokenHandler;
    }
}