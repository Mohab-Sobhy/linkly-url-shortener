
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace linkly_url_shortener.Models.EntitiesConfig
{
    public class URLDBConfigutation : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            ConfigureColumns(builder);
            ConfigureRelations(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(url => url.Id);
            builder.HasIndex(u => u.ShortCode).IsUnique();
            builder.Property(url => url.OriginalUrl).IsRequired();
            builder.Property(url => url.ShortCode).IsRequired().HasMaxLength(10);
            builder.Property(url => url.CreatedAt).IsRequired();
            builder.Property(url => url.UpdatedAt).IsRequired();
            builder.Property(url => url.IsActive).IsRequired();
            builder.Property(url => url.IsCustomName).IsRequired();
            Console.WriteLine("URL collumns configured");
        }
        public void ConfigureRelations(EntityTypeBuilder<Url> builder)
        {
            builder.HasOne(e => e.RegisterUser)
                .WithMany(u => u.Urls)
                .HasForeignKey(e => e.RegisterUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.GuestUser)
                .WithMany(u => u.Urls)
                .HasForeignKey(e => e.GuestUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}