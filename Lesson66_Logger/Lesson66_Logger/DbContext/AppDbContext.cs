using Lesson66_Logger.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson66_Logger.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Устанавливаем отношение «многие к одному» между товаром и категорией

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Устанавливаем самореферентную связь между категорией и ее родителем

        modelBuilder.Entity<Category>()
            .HasOne(c => c.CategoryParent)
            .WithMany(c => c.Childrens)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}