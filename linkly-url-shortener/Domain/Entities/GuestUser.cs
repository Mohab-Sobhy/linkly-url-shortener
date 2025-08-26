namespace linkly_url_shortener.Domain.Entities;

public class GuestUser
{
    public int Id { get; set; }
    public required byte[] SessionToken { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<Url> Urls { get; set; } = new List<Url>();
}