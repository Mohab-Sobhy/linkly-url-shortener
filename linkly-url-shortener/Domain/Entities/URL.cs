namespace linkly_url_shortener.Domain.Entities;
public class URL : IdentifiableEntity<int>
{
    public int UserId { get; set; }
    public int GuestId { get; set; }
    public string? OriginalUrl { get; set; }
    public string? ShortCode { get; set; }
    public string? QRCodePath { get; set; }
    public byte[]? PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Boolean IsActive { get; set; }
    public Boolean IsCustomeName { get; set; }
    public List<VisitLog>? VisitLogs { set; get; }
}
