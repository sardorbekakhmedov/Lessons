using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lesson_75_Docker.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lesson_75_Docker.Services;

public class JwtServices
{
    private readonly JwtSettings _jwtOptions;

    public JwtServices(IOptions<JwtSettings> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string GetJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.UserRole),
        };

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
            expires: utcNow.AddMinutes(5)
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return jwtToken;
    }
}