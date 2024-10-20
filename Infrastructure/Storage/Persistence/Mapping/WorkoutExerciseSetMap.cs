using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class WorkoutExerciseSetMap : IEntityTypeConfiguration<WorkoutExerciseSet>
{
    public void Configure(EntityTypeBuilder<WorkoutExerciseSet> builder)
    {
        // Table mapping
        builder.ToTable("WorkoutExerciseSets");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(wes => wes.Id);
        builder.Property(wes => wes.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        // RepCount property (required, integer)
        builder.Property(wes => wes.RepCount)
            .IsRequired()
            .HasColumnType("integer");

        // SetNumber property (required, integer)
        builder.Property(wes => wes.SetNumber)
            .IsRequired()
            .HasColumnType("integer");

        // Weight property (required, integer)
        builder.Property(wes => wes.Weight)
            .IsRequired()
            .HasColumnType("integer");

        // WorkoutExerciseId property (required foreign key, integer)
        builder.Property(wes => wes.WorkoutExerciseId)
            .IsRequired()
            .HasColumnType("integer");

        // Foreign key relationships
        builder.HasIndex(wes => wes.WorkoutExerciseId);  // Index on WorkoutExerciseId

        // Foreign key to WorkoutExercise (required)
        builder.HasOne(wes => wes.WorkoutExercise)
            .WithMany(we => we.WorkoutExerciseSets)  // Assuming WorkoutExercise has WorkoutExerciseSets collection
            .HasForeignKey(wes => wes.WorkoutExerciseId)
            .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on WorkoutExercise deletion
    }
}