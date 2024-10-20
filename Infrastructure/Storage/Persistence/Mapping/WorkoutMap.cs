using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class WorkoutMap : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        // CycleId property (nullable foreign key)
        builder.Property(w => w.CycleId)
            .HasColumnType("integer");  // Nullable foreign key

        // Date property (required, timestamp with time zone)
        builder.Property(w => w.Date)
            .IsRequired()
            .HasColumnType("timestamp with time zone");

        // UserId property (required, integer)
        builder.Property(w => w.UserId)
            .IsRequired()
            .HasColumnType("integer");

        // Foreign key relationships
        builder.HasIndex(w => w.CycleId);
        builder.HasIndex(w => w.UserId);

        // Foreign key to Cycle (optional)
        builder.HasOne(w => w.Cycle)
            .WithMany(c => c.Workouts)
            .HasForeignKey(w => w.CycleId)
            .OnDelete(DeleteBehavior.SetNull);  // Optional FK, set null on delete

        // Foreign key to User (required)
        builder.HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Required FK, cascade on delete
    }
}