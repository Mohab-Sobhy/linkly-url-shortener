namespace linkly_url_shortener.Application.DTO;

public class AuthenticateUserRequestDTO
{
    public required string Identifier { get; set; }
    public required string Password { get; set; }
}