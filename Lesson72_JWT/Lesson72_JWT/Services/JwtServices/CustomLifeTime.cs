using Microsoft.IdentityModel.Tokens;

namespace Lesson72_JWT.Services;

public class CustomLifeTime
{
  /*  public static bool CustomLifeTimeValidator(DateTime? notBefore, DateTime? expires,
            SecurityKey securityToken, TokenValidationParameters  validationParameters)
    {
        if (expires != null)
        {
            return expires > DateTime.UtcNow;
        }

        return false;
    }*/

    public static bool CustomLifeTimeValidator(DateTime? notBefore, DateTime? expires, 
        SecurityToken securityToken, TokenValidationParameters validationParameters)
    {
        if (expires != null)
        {
            return expires > DateTime.UtcNow;
        }

        return false;
    }
}