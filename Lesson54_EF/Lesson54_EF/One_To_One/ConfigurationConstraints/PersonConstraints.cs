using Lesson54_EF.One_To_One.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson54_EF.One_To_One.ConfigurationConstraints;

public class PersonConstraints : IEntityTypeConfiguration<Person> // IEntityTypeConfiguration<UserPassport> IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons").HasKey(i => i.Id).HasName("person_Id");

        builder.Property(p => p.FirstName).HasColumnName("first_name");
        builder.Property(p => p.LastName).HasColumnName("last_Name");

        builder.Property(p => p.Age)
            .HasColumnName("age")
            .IsRequired()
            .HasMaxLength(200)
            .HasDefaultValue(100);

        builder.Property(p => p.AddressId).HasColumnName("address_id");
      //  builder.Property(p => p.Address).HasColumnName("address_id2");
    }
}