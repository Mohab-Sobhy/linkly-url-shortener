
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
namespace linkly_url_shortener.Domain.EntitiesConfiguration
{
    public class GuestDBConfigutation : IEntityTypeConfiguration<GuestUser>
    {
        public void Configure(EntityTypeBuilder<GuestUser> builder)
        {
            ConfigureColumns(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(guest => guest.Id);
            builder.Property(guest => guest.SessionToken).IsRequired();
            builder.Property(guest => guest.DateUTC).IsRequired();
            Console.WriteLine("Guest collumns configured");
        }
        
    }
}