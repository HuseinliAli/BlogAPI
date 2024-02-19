using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;
internal class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("BlogPosts");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("int");
        builder.Property(b => b.UpdatedAt).HasColumnType("datetime");
        builder.Property(b => b.CreatedAt).HasColumnType("datetime").HasDefaultValue(DateTime.Now);

        builder.Property(b => b.ThumbnailImagePath).HasColumnType("varchar").HasMaxLength(150);

        builder.Property(b => b.ViewCount).HasColumnType("bigint").HasDefaultValue(0);

        builder.Property(b => b.Subject).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

        builder.Property(b => b.Content).HasColumnType("nvarchar").HasMaxLength(4000).IsRequired();

        builder.Property(b => b.CreatedBy).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(bp => bp.CreatedBy)
                .IsRequired();

        builder.Property(b => b.DeletedBy).HasColumnType("uniqueidentifier");
        builder.HasOne<User>()
                 .WithMany()
                 .HasForeignKey(bp => bp.CreatedBy)
                 .IsRequired();

        builder.Property(b => b.IsDelete).HasColumnType("bit").HasDefaultValue(false);
        builder.HasQueryFilter(t => t.IsDelete == false);
        builder.Property(b => b.DeletedAt).HasColumnType("datetime");
            
    }
}
