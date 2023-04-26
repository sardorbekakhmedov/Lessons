using EFCore.Data.DbContext.Configurations;
using EFCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserPassport> UserPassports { get; set; } = null!;

    public AppDbContext(DbContextOptions options) : base(options) { }

    // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    // Cheklovlarni ishga tushirish uchun
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //  base.OnModelCreating(modelBuilder);

        // new UserPassportConfiguration().Configure(modelBuilder.Entity<UserPassport>());   // Alohida tanlab ishga tushirish uchun.  Variant - 1
        // modelBuilder.ApplyConfiguration(new UserPassportConfiguration());  // Alohida tanlab ishga tushirish uchun. Variant - 2

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
    }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data.db");
        }*/
}