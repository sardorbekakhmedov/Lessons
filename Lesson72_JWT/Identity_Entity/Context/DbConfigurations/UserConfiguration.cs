using Identity_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_Data.Context.DbConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.FirstName)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property( p => p.UserName)
            
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(p => p.UserName)
            .IsUnique(true);

        //...
    }
}