using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class GymEquipmentMap : IEntityTypeConfiguration<GymEquipment>
{
    public void Configure(EntityTypeBuilder<GymEquipment> builder)
    {
        builder.ToTable("GymEquipments");

        builder.HasKey(ge => ge.Id);
        builder.Property(ge => ge.Id)
            .ValueGeneratedOnAdd();

        builder.Property(ge => ge.GymId)
            .IsRequired();

        builder.Property(ge => ge.Name)
            .IsRequired();

        builder.HasIndex(ge => ge.GymId);  
        builder.HasOne(ge => ge.Gym)
            .WithMany(g => g.GymEquipments)  
            .HasForeignKey(ge => ge.GymId)
            .OnDelete(DeleteBehavior.Cascade);  
    }
}