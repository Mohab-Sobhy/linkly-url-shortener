using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Enums;
using linkly_url_shortener.Infrastructure.Database;
using linkly_url_shortener.Models.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            List<object> configurations = new List<object>
                    {
                        new GuestDBConfigutation(),
                        new RegisterUserDBConfigutation(),
                        new URLDBConfigutation(),
                        new VisitLogDBConfigutation()
                    };
            foreach (var config in configurations)
            {
                modelBuilder.ApplyConfiguration((dynamic)config);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error configuring entities: " + ex.GetType() + ' ' + ex.Message);
        }
    }
}