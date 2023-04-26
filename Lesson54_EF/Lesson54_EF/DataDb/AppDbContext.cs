using Lesson54_EF.One_To_One.ConfigurationConstraints;
using Lesson54_EF.One_To_One.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson54_EF.DataDb;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //  optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source = Data.db");


        string path = "Server = (localdb)\\MSSQLLocalDB;" +
                                     "Database = testDB;" +
                                     "Trusted_Connection = True; ";
        optionsBuilder.UseSqlServer(path);

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}