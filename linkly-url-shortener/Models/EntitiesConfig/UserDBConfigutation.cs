
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
namespace linkly_url_shortener.Domain.EntitiesConfiguration
{
    public class RegisterUserDBConfigutation : IEntityTypeConfiguration<RegisterUser>
    {
        public void Configure(EntityTypeBuilder<RegisterUser> builder)
        {
            ConfigureColumns(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<RegisterUser> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Username).IsRequired();
            builder.Property(user => user.DateUTC).IsRequired();
            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.PasswordSalt).IsRequired();
            builder.Property(user => user.Role).IsRequired();
            builder.Property(user => user.CreatedAt).IsRequired();
            builder.Property(user => user.LastLoginAt).IsRequired();
            Console.WriteLine("User collumns configured");
        }
        
    }
}