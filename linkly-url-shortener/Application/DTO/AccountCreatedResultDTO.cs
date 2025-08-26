using linkly_url_shortener.Domain.Enums;

namespace linkly_url_shortener.Domain.DTO;

public class AccountCreatedResultDTO
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Role? Role { get; set; }
}