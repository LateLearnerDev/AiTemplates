using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping;

public class WorkoutExerciseMap : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        // Table mapping
        builder.ToTable("WorkoutExercises");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(we => we.Id);
        builder.Property(we => we.Id)
               .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
               .HasColumnType("integer");

        // ExerciseId property (required foreign key, integer)
        builder.Property(we => we.ExerciseId)
               .IsRequired()
               .HasColumnType("integer");

        // GymEquipmentId property (nullable foreign key, integer)
        builder.Property(we => we.GymEquipmentId)
               .HasColumnType("integer");  // Nullable

        // Notes property (optional, text type)
        builder.Property(we => we.Notes)
               .HasColumnType("text");  // Nullable (optional)

        // WorkoutId property (required foreign key, integer)
        builder.Property(we => we.WorkoutId)
               .IsRequired()
               .HasColumnType("integer");

        // Foreign key relationships
        builder.HasIndex(we => we.ExerciseId);  // Index on ExerciseId
        builder.HasIndex(we => we.GymEquipmentId);  // Index on GymEquipmentId
        builder.HasIndex(we => we.WorkoutId);  // Index on WorkoutId

        // Foreign key to Exercise (required)
        builder.HasOne(we => we.Exercise)
               .WithMany(e => e.WorkoutExercises)  // Assuming Exercise has WorkoutExercises collection
               .HasForeignKey(we => we.ExerciseId)
               .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on Exercise deletion

        // Foreign key to GymEquipment (optional)
        builder.HasOne(we => we.GymEquipment)
               .WithMany(ge => ge.WorkoutExercises)  // Assuming GymEquipment has WorkoutExercises collection
               .HasForeignKey(we => we.GymEquipmentId)
               .OnDelete(DeleteBehavior.SetNull);  // Set GymEquipmentId to null on GymEquipment deletion

        // Foreign key to Workout (required)
        builder.HasOne(we => we.Workout)
               .WithMany(w => w.WorkoutExercises)  // Assuming Workout has WorkoutExercises collection
               .HasForeignKey(we => we.WorkoutId)
               .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on Workout deletion
    }
}