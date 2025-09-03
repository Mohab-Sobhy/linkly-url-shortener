
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
            builder.Property(log => log.Country).HasMaxLength(45);
            builder.Property(log => log.IpAddress).HasMaxLength(50);
            builder.Property(log => log.Browser).HasMaxLength(50);
            builder.Property(log => log.OS).HasMaxLength(50);
            builder.Property(log => log.DeviceType).HasMaxLength(50);
        }
        public void ConfigureRelations(EntityTypeBuilder<VisitLog> builder)
        {
            builder.HasOne(e => e.Url)
                .WithMany(v => v.VisitLogs)
                .HasForeignKey(e => e.UrlId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}