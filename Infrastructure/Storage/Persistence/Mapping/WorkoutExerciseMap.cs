using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class WorkoutExerciseMap : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.ToTable("WorkoutExercises");

        builder.HasKey(we => we.Id);
        builder.Property(we => we.Id)
               .ValueGeneratedOnAdd();

        builder.Property(we => we.ExerciseId)
               .IsRequired();
        
        builder.Property(we => we.WorkoutId)
               .IsRequired();

        builder.HasIndex(we => we.ExerciseId); 
        builder.HasIndex(we => we.GymEquipmentId); 
        builder.HasIndex(we => we.WorkoutId); 

        builder.HasOne(we => we.Exercise)
               .WithMany(e => e.WorkoutExercises)  
               .HasForeignKey(we => we.ExerciseId)
               .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(we => we.GymEquipment)
               .WithMany(ge => ge.WorkoutExercises) 
               .HasForeignKey(we => we.GymEquipmentId)
               .OnDelete(DeleteBehavior.SetNull); 

        builder.HasOne(we => we.Workout)
               .WithMany(w => w.WorkoutExercises)
               .HasForeignKey(we => we.WorkoutId)
               .OnDelete(DeleteBehavior.Cascade); 
    }
}