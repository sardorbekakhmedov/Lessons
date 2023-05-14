using Lesson58_Identity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lesson58_Identity.DbContext;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Result> Results { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext>  options) : base( options )
    { }
}