using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping;

public class GymEquipmentExerciseMap : IEntityTypeConfiguration<GymEquipmentExercise>
{
    public void Configure(EntityTypeBuilder<GymEquipmentExercise> builder)
    {
        // Table mapping
        builder.ToTable("GymEquipmentExercises");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(gee => gee.Id);
        builder.Property(gee => gee.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        // ExerciseId property (required foreign key, integer)
        builder.Property(gee => gee.ExerciseId)
            .IsRequired()
            .HasColumnType("integer");

        // GymEquipmentId property (required foreign key, integer)
        builder.Property(gee => gee.GymEquipmentId)
            .IsRequired()
            .HasColumnType("integer");

        // Foreign key relationships
        builder.HasIndex(gee => gee.ExerciseId);  // Index on ExerciseId
        builder.HasIndex(gee => gee.GymEquipmentId);  // Index on GymEquipmentId

        // Foreign key to Exercise
        builder.HasOne(gee => gee.Exercise)
            .WithMany(e => e.GymEquipmentExercises)  // Assuming Exercise has GymEquipmentExercises collection
            .HasForeignKey(gee => gee.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on Exercise deletion

        // Foreign key to GymEquipment
        builder.HasOne(gee => gee.GymEquipment)
            .WithMany(ge => ge.GymEquipmentExercises)  // Assuming GymEquipment has GymEquipmentExercises collection
            .HasForeignKey(gee => gee.GymEquipmentId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}