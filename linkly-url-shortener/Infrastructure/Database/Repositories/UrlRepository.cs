using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Infrastructure.Database.Repositories;

public class UrlRepository : Repository<Url> , IUrlRepository
{
    public UrlRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<Url?> GetByShortCode(string shortCode)
    {
        return await DbSet.FirstOrDefaultAsync(u => u.ShortCode == shortCode);
    }
}