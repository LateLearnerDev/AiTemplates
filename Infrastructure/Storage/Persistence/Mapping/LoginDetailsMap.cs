using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class LoginDetailsMap : IEntityTypeConfiguration<LoginDetails>
{
    public void Configure(EntityTypeBuilder<LoginDetails> builder)
    {
        builder.ToTable("LoginDetails");

        builder.HasKey(ld => ld.Id);
        builder.Property(ld => ld.Id)
            .ValueGeneratedOnAdd();

        builder.Property(ld => ld.Username)
            .IsRequired();

        builder.Property(ld => ld.Password)
            .IsRequired();
    }
}