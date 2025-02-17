using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class CycleMap : IEntityTypeConfiguration<Cycle>
{
    public void Configure(EntityTypeBuilder<Cycle> builder)
    {
        builder.ToTable("Cycles");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired();

        builder.HasOne(c => c.User)
            .WithMany(u => u.Cycles)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);  

        builder.HasMany(c => c.Workouts)
            .WithOne(w => w.Cycle)
            .HasForeignKey(w => w.CycleId);
    }
}