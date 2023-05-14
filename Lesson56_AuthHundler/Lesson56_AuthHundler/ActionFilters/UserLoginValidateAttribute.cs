using System.Security.Claims;
using Lesson56_AuthorHundler.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lesson56_AuthorHundler.ActionFilters;

public class UserLoginValidateAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var HttpContext = context.HttpContext;

        if (HttpContext.Request.Cookies.ContainsKey("user_id"))
        {
            var cookieUserId = HttpContext.Request.Cookies["user_id"];

            var userId = Guid.Parse(cookieUserId);

            if (UsersData.Instance.Users.Any(i => i.Id == userId))
            {
                var user = UsersData.Instance.Users.Find(u => u.Id == userId);

                var claims = new List<Claim>
                {
                    new ("UserId", user.Id.ToString()),
                    new ("UserName", user.Name)
                };

               // HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims));
               
                context.Result = new UnauthorizedResult();

                // context.Result = new JsonResult(new
                // {
                //     Code = StatusCodes.Status401Unauthorized,
                //     Message = "Error code Unauthorized"
                // } );

                Console.WriteLine("Valid  login");
            }
            else
            {
                // context.HttpContext.Response.WriteAsJsonAsync(new
                // {
                //     Error = "Invalid not user in DB "
                // });

                context.Result = new UnauthorizedResult();

                //context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

                // context.Result = new JsonResult(new
                // {
                //     Code = StatusCodes.Status401Unauthorized,
                //     Message = "Error code Unauthorized"
                // } );

                Console.WriteLine("Invalid not user in DB ");
            }
        }
        else
        {
            context.HttpContext.Response.WriteAsJsonAsync(new
            {
                Error = "Invalid not login"
            });
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

            Console.WriteLine("Invalid not login");
        }
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("End  filter working");
    }

  
}