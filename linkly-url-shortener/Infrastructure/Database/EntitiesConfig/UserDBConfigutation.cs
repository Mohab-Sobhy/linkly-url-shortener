using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace linkly_url_shortener.Models.EntitiesConfig
{
    public class RegisterUserDBConfigutation : IEntityTypeConfiguration<RegisterUser>
    {
        public void Configure(EntityTypeBuilder<RegisterUser> builder)
        {
            ConfigureColumns(builder);
            ConfigureRelations(builder);
        }
        public void ConfigureColumns(EntityTypeBuilder<RegisterUser> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Username).IsRequired();
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.CreatedAt).IsRequired();
            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.PasswordSalt).IsRequired();
            builder.Property(user => user.Role).IsRequired();
            builder.Property(user => user.CreatedAt).IsRequired();
            builder.Property(user => user.LastLoginAt);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            Console.WriteLine("User collumns configured");
        }
        public void ConfigureRelations(EntityTypeBuilder<RegisterUser> builder)
        {
            builder
                .HasMany(e => e.Urls)
                .WithOne()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);;
            Console.WriteLine("RegisterUser-URLs relation configured");
        }
    }
}