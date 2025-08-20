
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace linkly_url_shortener.Models.EntitiesConfig
{
    public class VisitLogDBConfigutation : IEntityTypeConfiguration<VisitLog>
    {
        public void Configure(EntityTypeBuilder<VisitLog> builder)
        {
            ConfigureColumns(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<VisitLog> builder)
        {
            builder.HasKey(log => log.Id);
            builder.Property(log => log.UrlId);
            builder.Property(log => log.VisitedAt).IsRequired();
            builder.Property(log => log.Country).IsRequired().HasMaxLength(45);
            builder.Property(log => log.IPAddress).IsRequired().HasMaxLength(50);
            builder.Property(log => log.Browser).IsRequired().HasMaxLength(50);
            builder.Property(log => log.OS).IsRequired().HasMaxLength(50);
            builder.Property(log => log.DeviceType).IsRequired().HasMaxLength(50);
            Console.WriteLine("log collumns configured");
        }
    }
}