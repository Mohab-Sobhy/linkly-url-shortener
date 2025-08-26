using System.Security.Cryptography;
using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.DTO;
using linkly_url_shortener.Domain.Enums;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using linkly_url_shortener.Utils;

namespace linkly_url_shortener.Application;

public class UserService
{
    private readonly IRepository<RegisterUser> _userRepository;

    public UserService(IRepository<RegisterUser> userRepository)
    {
        _userRepository = userRepository;
    }
    
    public AccountCreatedResultDTO CreateAccount(CreateAccountRequestDTO requestDto)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        RegisterUser newUser = new RegisterUser
        {
            Username = requestDto.Username,
            Email = requestDto.Email,
            PasswordSalt = salt,
            PasswordHash = StringHasher.HashToSha256(requestDto.Password , salt),
            Role = Role.RegularUser,
            CreatedAt = DateTime.UtcNow
        };
        
        _userRepository.AddAsync(newUser);
        
        return new AccountCreatedResultDTO
        {
            Username = newUser.Username,
            Email = newUser.Email,
            Role = newUser.Role,
        };
        
        
    }
}