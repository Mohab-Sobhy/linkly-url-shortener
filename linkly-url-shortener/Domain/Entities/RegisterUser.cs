using linkly_url_shortener.Domain.Entities;

namespace linkly_url_shortener.Domain.Enums;

public class RegisterUser
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; } 
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public required Role Role { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    
    public ICollection<Url> Urls { get; set; } = new List<Url>();
}