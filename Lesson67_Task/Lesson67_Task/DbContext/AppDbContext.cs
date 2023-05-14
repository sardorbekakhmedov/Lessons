
using Lesson67_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson67_Task.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasOne(category => category.CategoryParent)
                .WithMany(category => category.Childrens)
                    .HasForeignKey(category => category.ParentId)
                        .OnDelete(DeleteBehavior.NoAction);
    }
}