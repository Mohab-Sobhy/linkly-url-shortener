
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using linkly_url_shortener.Domain.Enums;
namespace linkly_url_shortener.Models.EntitiesConfig
{
    public class URLDBConfigutation : IEntityTypeConfiguration<URL>
    {
        public void Configure(EntityTypeBuilder<URL> builder)
        {
            ConfigureColumns(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<URL> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.OriginalURL).IsRequired();
            builder.Property(user => user.ShortCode).IsRequired().HasMaxLength(20);
            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.QRCodePath).IsRequired();
            builder.Property(user => user.CreatedAt).IsRequired();
            builder.Property(user => user.ExpirationDate).IsRequired();
            builder.Property(user => user.UpdatedAt).IsRequired();
            builder.Property(user => user.IsActive).IsRequired();
            builder.Property(user => user.IsCustomeName).IsRequired();
            Console.WriteLine("URL collumns configured");
        }
    }
}