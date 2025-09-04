
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace linkly_url_shortener.Models.EntitiesConfig
{
    public class GuestDBConfigutation : IEntityTypeConfiguration<GuestUser>
    {
        public void Configure(EntityTypeBuilder<GuestUser> builder)
        {
            ConfigureColumns(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<GuestUser> builder)
        {
            builder.HasKey(guest => guest.Id);
            builder.Property(guest => guest.SessionToken).IsRequired();
            builder.Property(guest => guest.CreatedAt).IsRequired();
            builder.HasIndex(guest => guest.SessionToken).IsUnique();
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            Console.WriteLine("Guest collumns configured");
        }
    }
}