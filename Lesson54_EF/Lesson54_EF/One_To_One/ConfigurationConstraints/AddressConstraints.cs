using Lesson54_EF.One_To_One.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson54_EF.One_To_One.ConfigurationConstraints;

public class AddressConstraints : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses").HasKey(i => i.Id).HasName("manzil_Id");

        builder.Property(p => p.Region).HasColumnName("viloyat");
        builder.Property(p => p.City).HasColumnName("shahar");
        builder.Property(p => p.District).HasColumnName("tuman");
        builder.Property(p => p.Village).HasColumnName("qishloq");

    }
}