namespace linkly_url_shortener.Domain.Entities;

public class GuestUser : Identifiable<int>
{
    public int Id { get; set; }
    public required byte[] SessionToken { get; set; }
    public DateTime CreatedAt { get; set; }
}