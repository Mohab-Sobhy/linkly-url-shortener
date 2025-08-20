namespace linkly_url_shortener.Domain.Entities;
public class GuestUser : IdentifiableEntity<int>
{
    public required byte[] SessionToken { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<URL>? URLs { set; get; }
}