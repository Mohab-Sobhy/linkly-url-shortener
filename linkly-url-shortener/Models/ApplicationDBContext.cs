using System;
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Domain.Entities;
namespace linkly_url_shortener.Domain
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";
            try
            {
                optionsBuilder.UseSqlServer(connectionString);
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
                var configurations = new List<IEntityTypeConfiguration>
                    {
                        new GuestDBConfiguration(),
                        new RegisteredUserDBConfiguration()
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
    
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }
    }
}

