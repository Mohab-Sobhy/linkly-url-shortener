namespace linkly_url_shortener.Application.DTO;

public class LogVisitDto
{
    public required int UrlId {get; set;}
    public required string IpAddress {get; set;}
    public string? UserAgent {get; set;}
    public string? Referer {get; set;}
}