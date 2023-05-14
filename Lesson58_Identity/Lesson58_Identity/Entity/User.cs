using Microsoft.AspNetCore.Identity;

namespace Lesson58_Identity.Entity;

public class User : IdentityUser<Guid>
{
    public List<Result> Results { get; set; }
}