using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Models.EntitiesConfig;
using linkly_url_shortener.Domain.Enums;
namespace linkly_url_shortener.Models
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";
            try
            {
                optionsBuilder.UseNpgsql(connectionString);
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                List<object> configurations = new List<object>
                    {
                        new GuestDBConfigutation(),
                        new RegisterUserDBConfigutation()
                    };
                foreach (var config in configurations)
                {
                    modelBuilder.ApplyConfiguration((dynamic)config);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error configuring entities: "+ ex.GetType() +' ' + ex.Message);
            }
        }
    
        public DbSet<RegisterUser> RegisterUsers { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }
        public DbSet<URL> URLs { get; set; }
    }
}

