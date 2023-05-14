using System.Security.Claims;
using System.Text.Encodings.Web;
using Lesson57_Authentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lesson57_Authentication.Authentication;

public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly UserData _userData;

    public AuthHandler( 
        IOptionsMonitor<AuthenticationSchemeOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock,
        UserData userData) : base(options, logger, encoder, clock)
    {
        _userData = userData;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        User user;

        var cookies = Context.Request.Cookies;

        if (cookies.ContainsKey(ClaimTypes.Name))
        {
            var userId = cookies[ClaimTypes.Name];

            if (_userData.Users.Any(i => i.Id == userId))
            {
                user = _userData.Users.First(i => i.Id == userId);
            }
            else
            {
                var user2 = new User()
                {
                    Name = "Maraymamat",
                    Age = 111,
                    Id = Guid.NewGuid().ToString(),
                };

                user = user2;

                _userData.Users.Add(user);
                Context.Response.Cookies.Append(ClaimTypes.NameIdentifier.Substring(1), user.Id);
             //   Context.Response.Cookies.Append(ClaimTypes, user.Id);
            }
        }
        else
        {
            var user2 = new User()
            {
                Name = "Maraymamat",
                Age = 111,
                Id = Guid.NewGuid().ToString(),
            };

            user = user2;

            _userData.Users.Add(user);

            Context.Response.Cookies.Append(ClaimTypes.NameIdentifier.Substring(1), user.Id);
        }


        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.Name!)
        };

        var userClaim = new ClaimsPrincipal(new ClaimsIdentity(claims));

        var ticket = new AuthenticationTicket(userClaim, Scheme.Name);

        return await Task.FromResult(AuthenticateResult.Success(ticket));
    }

}