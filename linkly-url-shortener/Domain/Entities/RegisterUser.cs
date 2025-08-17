namespace linkly_url_shortener.Domain.Enums;

public class RegisterUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; } 
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastLoginAt { get; set; }
}