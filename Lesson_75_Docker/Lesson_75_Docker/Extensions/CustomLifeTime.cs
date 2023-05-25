using Microsoft.IdentityModel.Tokens;

namespace Lesson_75_Docker.Extensions;

public class CustomLifeTime
{
    public static bool CustomLifeTimeValidator(DateTime? notBefore, DateTime? expires,
        SecurityToken securityToken, TokenValidationParameters validationParameters)
    {
        if (expires is not null)
        {
            return expires > DateTime.UtcNow;
        }

        return false;
    }
}