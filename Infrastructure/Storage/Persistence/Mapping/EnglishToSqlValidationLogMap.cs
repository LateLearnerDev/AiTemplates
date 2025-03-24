using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Persistence.Mapping;

public class EnglishToSqlValidationLogMap : IEntityTypeConfiguration<EnglishToSqlValidationLog>
{
    public void Configure(EntityTypeBuilder<EnglishToSqlValidationLog> builder)
    {
        builder.ToTable("EnglishToSqlValidationLog");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
            .ValueGeneratedOnAdd();

    }
}

