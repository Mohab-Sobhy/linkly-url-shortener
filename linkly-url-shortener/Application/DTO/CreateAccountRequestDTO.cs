namespace linkly_url_shortener.Application.DTO;

public class CreateAccountRequestDTO
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}