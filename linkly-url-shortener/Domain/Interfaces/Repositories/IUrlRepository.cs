using linkly_url_shortener.Domain.Entities;

namespace linkly_url_shortener.Domain.Interfaces.Repositories;

public interface IUrlRepository
{
    public Task<Url?> GetByShortCode(string shortCode);
    public Task AddAsync(Url entity);
    public IQueryable<Url> GetByUser(int userId);
    public IQueryable<Url> GetByUser(RegisterUser? user);
}