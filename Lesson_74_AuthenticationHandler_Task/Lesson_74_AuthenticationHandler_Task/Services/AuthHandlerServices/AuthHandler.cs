using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Lesson_74_AuthenticationHandler_Task.Services.AuthHandlerServices;

public class AuthHandler : AuthenticationHandler<JwtBearerOptions>
{
    private readonly TokenValidationParameters _tokenValidationParameters;

    public AuthHandler(
        IOptionsMonitor<JwtBearerOptions> options,
            ILoggerFactory logger,
                UrlEncoder encoder,
                    ISystemClock clock,
                        TokenValidationParameters tokenValidationParameters)
                            : base(options, logger, encoder, clock)
    {
        _tokenValidationParameters = tokenValidationParameters;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        /*        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            return AuthenticateResult.Fail("Missing token");
        }
*/
       
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization header");
        }
        
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;

            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Invalid token");
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(principal.Claims, Scheme.Name);

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);

            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail("Invalid token: " + ex.Message);
        }
    }
}