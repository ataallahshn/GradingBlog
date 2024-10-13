using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingBlog.DataLayer.Posts;

public sealed class PostHistoryTypeConfiguration : IEntityTypeConfiguration<PostHistory>
{
    public void Configure(EntityTypeBuilder<PostHistory> builder)
    {
        builder.ToTable(nameof(PostHistory));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.From)
            .IsRequired();

        builder
            .Property(x => x.To)
            .IsRequired();

        builder
            .Property(x => x.ChangedOn)
            .IsRequired();

        builder
            .HasOne(x => x.Post)
            .WithMany(x => x.PostHistories)
            .HasForeignKey(x => x.PostId);
    }
}