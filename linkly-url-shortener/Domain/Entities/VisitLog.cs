namespace linkly_url_shortener.Domain.Entities;
public class VisitLog : IdentifiableEntity<int>
{
    public int VisitId { get; set; }
    public int UrlId { get; set; }
    public DateTime VisitedAt { get; set; } 
    public string? IPAddress { get; set; } 
    public string? Country { get; set; } 
    public string? Browser { get; set; } 
    public string? OS { get; set; } 
    public string? DeviceType { get; set; } 
}
