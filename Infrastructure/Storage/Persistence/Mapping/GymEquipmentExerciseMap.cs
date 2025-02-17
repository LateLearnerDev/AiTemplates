using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class GymEquipmentExerciseMap : IEntityTypeConfiguration<GymEquipmentExercise>
{
    public void Configure(EntityTypeBuilder<GymEquipmentExercise> builder)
    {
        builder.ToTable("GymEquipmentExercises");

        builder.HasKey(gee => gee.Id);
        builder.Property(gee => gee.Id)
            .ValueGeneratedOnAdd();

        builder.Property(gee => gee.ExerciseId)
            .IsRequired();

        builder.Property(gee => gee.GymEquipmentId)
            .IsRequired();

        builder.HasIndex(gee => gee.ExerciseId);  
        builder.HasIndex(gee => gee.GymEquipmentId);  
        
        builder.HasOne(gee => gee.Exercise)
            .WithMany(e => e.GymEquipmentExercises)  
            .HasForeignKey(gee => gee.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);  
        
        builder.HasOne(gee => gee.GymEquipment)
            .WithMany(ge => ge.GymEquipmentExercises)  
            .HasForeignKey(gee => gee.GymEquipmentId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}