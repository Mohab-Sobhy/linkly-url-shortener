using linkly_url_shortener.Domain.Entities;

namespace linkly_url_shortener.Domain.Interfaces.Repositories;

public interface IRegisterUserRepository
{
    Task<RegisterUser?> GetByUsernameAsync(string username);
    Task<bool> ExistsByUsernameAsync(string username);
    Task<RegisterUser?> GetByEmailAsync(string username);
    public Task<bool> ExistsByEmailAsync(string email);
}