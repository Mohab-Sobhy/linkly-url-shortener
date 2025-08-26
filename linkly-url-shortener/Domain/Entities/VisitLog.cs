namespace linkly_url_shortener.Domain.Entities;

public class VisitLog
{
    public int Id { get; set; }
    public required Url Url { get; set; }
    public required int UrlId { get; set; }
    public required DateTime VisitedAt { get; set; }
    public required string IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Referer { get; set; }
    //extracted from ip & useragent
    public string? Country {get; set;}
    public string? Browser { get; set; }
    public string? OS { get; set; }
    public string? DeviceType { get; set; }
}