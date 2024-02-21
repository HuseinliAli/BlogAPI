using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class VoteBlogPostConfiguration : IEntityTypeConfiguration<VoteBlogPost>
{
    public void Configure(EntityTypeBuilder<VoteBlogPost> builder)
    {
        builder.ToTable("VoteBlogPosts");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).HasColumnType("int");

        builder.Property(v => v.UpdatedAt).HasColumnType("datetime").IsRequired(false);
        builder.Property(v => v.CreatedAt).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
        
        builder.Property(v => v.VoteType).HasDefaultValue(VoteType.None).HasConversion<string>();

        builder.Property(v => v.BlogPostId).HasColumnType("int");
     
        builder.Property(v => v.UserId).HasColumnType("uniqueidentifier");

        builder.Property(b => b.IsDelete).HasColumnType("bit").HasDefaultValue(false);
        builder.HasQueryFilter(t => t.IsDelete == false);
        builder.Property(b => b.DeletedAt).HasColumnType("datetime").IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction); ;
        builder.HasOne<BlogPost>().WithMany().HasForeignKey(v => v.BlogPostId).OnDelete(DeleteBehavior.NoAction); ;

    }
}
