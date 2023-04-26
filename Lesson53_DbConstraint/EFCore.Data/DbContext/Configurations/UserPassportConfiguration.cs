
using EFCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCore.Data.DbContext.Configurations;

public class UserPassportConfiguration : IEntityTypeConfiguration<UserPassport> // Interface
{

    // Cheklovlarni yozib chiqish uchun
    public void Configure(EntityTypeBuilder<UserPassport> builder)
    {
        builder.ToTable("user_passport").HasKey(i => i.Id);

        builder.Property(p => p.Serial)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("serial")
        .HasDefaultValue("AA");

        builder.Property(p => p.Pnfl)
            .IsRequired()
            .HasColumnName("pnfl")
            .HasMaxLength(14)
        .IsFixedLength();

        builder.Property(p => p.SerialNumber)
            .IsRequired()
            .HasMaxLength(7)
            .HasColumnName("serial_numbers")
            .HasComment("Hello this is first comment");

        builder.Property(p => p.Tin)
            .IsRequired()
            .HasMaxLength(3)
        .IsFixedLength();

        builder.Property(p => p.UserId)
            .HasColumnName("user_id");
    }
}
