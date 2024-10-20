using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class CycleMap : IEntityTypeConfiguration<Cycle>
{
    public void Configure(EntityTypeBuilder<Cycle> builder)
    {
        builder.ToTable("Cycles");

        // Primary key
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        // Required fields
        builder.Property(c => c.Name)
            .IsRequired()  // Snapshot shows this as required
            .HasColumnType("text");

        // Optional fields
        builder.Property(c => c.StartDate)
            .HasColumnType("timestamp with time zone");  // Align with snapshot

        builder.Property(c => c.EndDate)
            .HasColumnType("timestamp with time zone");  // Align with snapshot

        builder.Property(c => c.LengthInWeeks)
            .HasColumnType("integer");  // Align with snapshot

        // Foreign key relationship with User
        builder.HasOne(c => c.User)
            .WithMany(u => u.Cycles)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Add Cascade if necessary

        // One-to-many relationship with Workouts
        builder.HasMany(c => c.Workouts)
            .WithOne(w => w.Cycle)
            .HasForeignKey(w => w.CycleId);
    }
}