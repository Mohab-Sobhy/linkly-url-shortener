using linkly_url_shortener.Domain.Interfaces;
using linkly_url_shortener.Domain.Interfaces.Repositories;

namespace linkly_url_shortener.Application.Background;

public class VisitorInfoUpdaterService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IUserAgentParser _uaService;
    private readonly HttpClient _httpClient;

    public VisitorInfoUpdaterService(IServiceScopeFactory scopeFactory, IUserAgentParser uaService,
        IHttpClientFactory httpClientFactory)
    {
        _scopeFactory = scopeFactory;
        _uaService = uaService;
        _httpClient = httpClientFactory.CreateClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IVisitLogRepository>();

            var logs = await repository.GetNotUpdatedVisitLogsAsync();

            if (logs == null || !logs.Any())
            {
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                continue;
            }

            foreach (var log in logs)
            {
                if (!string.IsNullOrEmpty(log.UserAgent))
                {
                    var parsedUa = _uaService.Parse(log.UserAgent);
                    log.Browser = parsedUa.Browser;
                    log.OS = parsedUa.OS;
                    log.DeviceType = parsedUa.Device;
                }
                else
                {
                    log.Browser = log.OS = log.DeviceType = "Unknown";
                }

                if (!string.IsNullOrEmpty(log.IpAddress))
                {
                    try
                    {
                        var url = $"http://ip-api.com/json/{log.IpAddress}?fields=country";
                        var response = await _httpClient.GetFromJsonAsync<IpApiResponse>(url, stoppingToken);
                        log.Country = response?.Country ?? "Unknown";
                    }
                    catch
                    {
                        log.Country = "Unknown";
                    }
                }
            }

            await repository.UpdateRangeAsync(logs);

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}

public class IpApiResponse
{
    public string? Country { get; set; }
}
