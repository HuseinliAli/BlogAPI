using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class UserOperationConfiguration : IEntityTypeConfiguration<UserOperation>
{
    public void Configure(EntityTypeBuilder<UserOperation> builder)
    {
        builder.ToTable("UserOperations");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("int");

        builder.Property(u => u.UpdatedAt).HasColumnType("datetime");
        builder.Property(u => u.CreatedAt).HasColumnType("datetime").HasDefaultValue(DateTime.Now);

        builder.Property(u => u.UserId).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasOne<User>().WithMany().HasForeignKey(u => u.UserId);

        builder.Property(u => u.OperationClaimId).HasColumnType("int").IsRequired();
        builder.HasOne<OperationClaim>().WithMany().HasForeignKey(u => u.OperationClaimId);

    }
}
