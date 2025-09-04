using linkly_url_shortener.Domain.Entities;

namespace linkly_url_shortener.Domain.Interfaces.Repositories;

public interface IVisitLogRepository : IRepository<VisitLog>
{
    public Task< List<VisitLog>? > GetNotUpdatedVisitLogsAsync();
}