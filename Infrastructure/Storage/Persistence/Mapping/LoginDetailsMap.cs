using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class LoginDetailsMap : IEntityTypeConfiguration<LoginDetails>
{
    public void Configure(EntityTypeBuilder<LoginDetails> builder)
    {
        // Table mapping
        builder.ToTable("LoginDetails");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(ld => ld.Id);
        builder.Property(ld => ld.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        // Username property (required, text type)
        builder.Property(ld => ld.Username)
            .IsRequired()
            .HasColumnType("text");

        // Password property (required, text type)
        builder.Property(ld => ld.Password)
            .IsRequired()
            .HasColumnType("text");
    }
}