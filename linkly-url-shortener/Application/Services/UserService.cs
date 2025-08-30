using System.Security.Cryptography;
using FluentValidation;
using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Enums;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using linkly_url_shortener.Utils;

namespace linkly_url_shortener.Application.Services;

public class UserService
{
    private readonly IRepository<RegisterUser> _userRepository;
    private readonly IValidator<CreateAccountRequestDTO> _validator;

    public UserService(IRepository<RegisterUser> userRepository , IValidator<CreateAccountRequestDTO> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }
    
    public async Task<AccountCreatedResultDTO> CreateAccount(CreateAccountRequestDTO requestDto)
    {
        var result = _validator.Validate(requestDto);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
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
        
        await _userRepository.AddAsync(newUser);
        
        return new AccountCreatedResultDTO
        {
            Username = newUser.Username,
            Email = newUser.Email,
            Role = newUser.Role,
        };
    }
    
    
    
}