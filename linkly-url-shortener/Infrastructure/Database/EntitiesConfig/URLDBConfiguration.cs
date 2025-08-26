
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
            builder.Property(url => url.RegisterUserId).IsRequired();
            builder.Property(url => url.GuestUserId).IsRequired();
            builder.Property(url => url.OriginalUrl).IsRequired();
            builder.Property(url => url.ShortCode).IsRequired().HasMaxLength(20);;
            builder.Property(url => url.CreatedAt).IsRequired();
            builder.Property(url => url.UpdatedAt).IsRequired();
            builder.Property(url => url.IsActive).IsRequired();
            builder.Property(url => url.IsCustomName).IsRequired();
            Console.WriteLine("URL collumns configured");
        }
        public void ConfigureRelations(EntityTypeBuilder<Url> builder)
        {
            builder
                .HasMany(e => e.VisitLogs)
                .WithOne()
                .HasForeignKey("UrlId")
                .OnDelete(DeleteBehavior.Cascade);
            Console.WriteLine("URL-VisitLogs relation configured");
        }
    }
}