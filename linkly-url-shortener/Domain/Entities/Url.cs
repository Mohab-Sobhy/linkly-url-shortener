using linkly_url_shortener.Domain.Enums;

namespace linkly_url_shortener.Domain.Entities;

public class Url
{
    public int Id { get; set; }
    public RegisterUser? RegisterUser { get; set; }
    public int? RegisterUserId { get; set; }
    public GuestUser? GuestUser { get; set; }
    public int? GuestUserId { get; set; }

    public required string OriginalUrl { get; set; }
    public required string ShortCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsCustomName {get; set;}

    public ICollection<VisitLog> VisitLogs { get; set; } = new List<VisitLog>();
}