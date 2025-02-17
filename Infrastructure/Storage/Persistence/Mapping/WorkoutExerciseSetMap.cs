using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class WorkoutExerciseSetMap : IEntityTypeConfiguration<WorkoutExerciseSet>
{
    public void Configure(EntityTypeBuilder<WorkoutExerciseSet> builder)
    {
        builder.ToTable("WorkoutExerciseSets");

        builder.HasKey(wes => wes.Id);
        builder.Property(wes => wes.Id)
            .ValueGeneratedOnAdd();

        builder.Property(wes => wes.RepCount)
            .IsRequired();

        builder.Property(wes => wes.SetNumber)
            .IsRequired();
        
        builder.Property(wes => wes.Weight)
            .IsRequired();

        builder.Property(wes => wes.WorkoutExerciseId)
            .IsRequired();

        builder.HasIndex(wes => wes.WorkoutExerciseId); 

        builder.HasOne(wes => wes.WorkoutExercise)
            .WithMany(we => we.WorkoutExerciseSets) 
            .HasForeignKey(wes => wes.WorkoutExerciseId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}