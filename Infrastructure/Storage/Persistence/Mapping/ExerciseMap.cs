using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class ExerciseMap : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        // Description property (optional, text type)
        builder.Property(e => e.Description)
            .HasColumnType("text");  // Nullable (optional)

        // Name property (required, text type)
        builder.Property(e => e.Name)
            .IsRequired()  // Required
            .HasColumnType("text");
    }
}