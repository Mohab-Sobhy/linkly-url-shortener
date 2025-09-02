using linkly_url_shortener.Domain.Entities;

namespace linkly_url_shortener.Domain.Interfaces;

public interface ITokenGenerator
{
    public String GenerateJwtToken(RegisterUser user);
}