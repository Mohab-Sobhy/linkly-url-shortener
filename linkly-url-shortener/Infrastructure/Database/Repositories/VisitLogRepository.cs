using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Infrastructure.Database.Repositories;

public class VisitLogRepository : Repository<VisitLog>, IVisitLogRepository
{
    public VisitLogRepository(AppDbContext dbContext) : base(dbContext) { }
    
    public async Task< List<VisitLog>? > GetNotUpdatedVisitLogsAsync()
    {
        return await DbSet.Where(v => string.IsNullOrEmpty(v.Browser)).ToListAsync();
    }
}