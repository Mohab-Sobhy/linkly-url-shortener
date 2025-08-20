
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace linkly_url_shortener.Models.EntitiesConfig
{
    public class URLDBConfigutation : IEntityTypeConfiguration<URL>
    {
        public void Configure(EntityTypeBuilder<URL> builder)
        {
            ConfigureColumns(builder);
            ConfigureRelations(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<URL> builder)
        {
            builder.HasKey(url => url.Id);
            builder.Property(url => url.OriginalUrl).IsRequired();
            builder.Property(url => url.ShortCode).IsRequired().HasMaxLength(20);
            builder.Property(url => url.PasswordHash).IsRequired();
            builder.Property(url => url.QRCodePath).IsRequired();
            builder.Property(url => url.CreatedAt).IsRequired();
            builder.Property(url => url.ExpirationDate).IsRequired();
            builder.Property(url => url.UpdatedAt).IsRequired();
            builder.Property(url => url.IsActive).IsRequired();
            builder.Property(url => url.IsCustomeName).IsRequired();
            Console.WriteLine("URL collumns configured");
        }
        public void ConfigureRelations(EntityTypeBuilder<URL> builder)
        {
            builder
                .HasMany(e => e.VisitLogs)
                .WithOne()
                .HasForeignKey("UrlId");
            Console.WriteLine("URL-VisitLogs relation configured");
        }
    }
}