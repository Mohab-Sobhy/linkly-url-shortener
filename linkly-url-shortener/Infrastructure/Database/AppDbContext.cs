using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisterUser>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<GuestUser>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        
        modelBuilder.Entity<VisitLog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Url)
                .WithMany(v => v.VisitLogs)
                .HasForeignKey(e => e.UrlId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Url>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.RegisterUser)
                .WithMany(u => u.Urls)
                .HasForeignKey(e => e.RegisterUserId)
                .OnDelete(DeleteBehavior.Cascade);
    
            
            entity.HasOne(e => e.GuestUser)
                .WithMany(u => u.Urls)
                .HasForeignKey(e => e.GuestUserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}