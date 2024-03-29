﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("Operations");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("int");

        builder.Property(u => u.UpdatedAt).HasColumnType("datetime").IsRequired(false);
        builder.Property(u => u.CreatedAt).HasColumnType("datetime").HasDefaultValue(DateTime.Now);


        builder.Property(b => b.IsDelete).HasColumnType("bit").HasDefaultValue(false);
        builder.HasQueryFilter(t => t.IsDelete == false);
        builder.Property(b => b.DeletedAt).HasColumnType("datetime").IsRequired(false);

        builder.Property(u => u.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
    }
}
