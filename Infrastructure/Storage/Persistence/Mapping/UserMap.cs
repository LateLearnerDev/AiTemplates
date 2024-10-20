using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()  // Identity column for PostgreSQL
            .HasColumnType("integer");

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(u => u.LastName) 
            .IsRequired()
            .HasColumnType("text");

        builder.Property(u => u.LoginId)
            .HasColumnType("integer");  // Nullable foreign key
        builder.HasIndex(u => u.LoginId);
        builder.HasOne(u => u.LoginDetails)
            .WithMany() 
            .HasForeignKey(u => u.LoginId);
    }
}