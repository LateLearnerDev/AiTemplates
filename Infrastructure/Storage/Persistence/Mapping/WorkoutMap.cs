using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class WorkoutMap : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id)
            .ValueGeneratedOnAdd();


        builder.Property(w => w.Date)
            .IsRequired();

        builder.Property(w => w.UserId)
            .IsRequired();

        builder.HasIndex(w => w.CycleId);
        builder.HasIndex(w => w.UserId);

        builder.HasOne(w => w.Cycle)
            .WithMany(c => c.Workouts)
            .HasForeignKey(w => w.CycleId)
            .OnDelete(DeleteBehavior.SetNull); 

        builder.HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}