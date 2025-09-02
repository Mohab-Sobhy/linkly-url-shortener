using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;

namespace linkly_url_shortener.Application.Services;

public class LoggingService
{
    private readonly IRepository<VisitLog> _visitLogger;

    public LoggingService(IRepository<VisitLog> visitLogger)
    {
        _visitLogger = visitLogger;
    }

    public void LogVisit(LogVisitDto visit)
    {
        VisitLog newVisitLog = new VisitLog
        {
            UrlId = visit.UrlId,
            IpAddress = visit.IpAddress,
            UserAgent = visit.UserAgent,
            Referer = visit.Referer,
            VisitedAt = DateTime.UtcNow
        };
            
        _visitLogger.AddAsync(newVisitLog);
    }
}