using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uniqueidentifier");

        builder.Property(u => u.UpdatedAt).HasColumnType("datetime").IsRequired(false);
        builder.Property(u => u.CreatedAt).HasColumnType("datetime").HasDefaultValue(DateTime.Now);

        builder.Property(u => u.FirstName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(); 
        builder.Property(u => u.LastName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();

        builder.Property(u => u.RefreshToken).HasColumnType("varchar").IsRequired().HasMaxLength(500);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.PasswordSalt).IsRequired();
        builder.Property(u => u.IsActive).HasColumnType("bit").HasDefaultValue(true);

        builder.Property(b => b.IsDelete).HasColumnType("bit").HasDefaultValue(false);
        builder.HasQueryFilter(t => t.IsDelete == false);
        builder.Property(b => b.DeletedAt).HasColumnType("datetime").IsRequired(false);
    }
}
