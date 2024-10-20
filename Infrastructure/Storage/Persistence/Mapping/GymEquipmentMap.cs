using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class GymEquipmentMap : IEntityTypeConfiguration<GymEquipment>
{
    public void Configure(EntityTypeBuilder<GymEquipment> builder)
    {
        builder.ToTable("GymEquipments");

        // Primary key with auto-increment (PostgreSQL identity)
        builder.HasKey(ge => ge.Id);
        builder.Property(ge => ge.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        // GymId property (required foreign key, integer)
        builder.Property(ge => ge.GymId)
            .IsRequired()
            .HasColumnType("integer");

        // Name property (required, text type)
        builder.Property(ge => ge.Name)
            .IsRequired()  // Required
            .HasColumnType("text");

        // Foreign key relationship with Gym
        builder.HasIndex(ge => ge.GymId);  // Index on GymId
        builder.HasOne(ge => ge.Gym)
            .WithMany(g => g.GymEquipments)  // Assuming Gym has a GymEquipments collection
            .HasForeignKey(ge => ge.GymId)
            .OnDelete(DeleteBehavior.Cascade);  
    }
}