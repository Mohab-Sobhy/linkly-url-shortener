using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Infrastructure.Database.Repositories;

public class RegisterUserRepository : Repository<RegisterUser> , IRegisterUserRepository
{
    public RegisterUserRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<RegisterUser?> GetByUsernameAsync(string username)
    {
        return await DbSet.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await DbSet.AnyAsync(u => u.Username == username);
    }

    public async Task<RegisterUser?> GetByEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await DbSet.AnyAsync(u => u.Email == email);
    }

    public async Task UpdateLastLoginAsync(RegisterUser user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.LastLoginAt = DateTime.UtcNow;
        await Context.SaveChangesAsync();
    }

}