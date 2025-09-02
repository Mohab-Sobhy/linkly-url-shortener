using linkly_url_shortener.Domain.Entities;

namespace linkly_url_shortener.Domain.Interfaces.Repositories;

public interface IUrlRepository
{
    public Task<Url?> GetByShortCode(string shortCode);
}