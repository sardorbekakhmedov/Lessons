using Lesson_75_Docker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson_75_Docker.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("users");

    }
}