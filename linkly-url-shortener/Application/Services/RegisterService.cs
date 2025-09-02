using System.Security.Cryptography;
using FluentValidation;
using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Enums;
using linkly_url_shortener.Domain.Interfaces;
using linkly_url_shortener.Domain.Interfaces.Repositories;

namespace linkly_url_shortener.Application.Services;

public class RegisterService
{
    private readonly IRepository<RegisterUser> _userRepository;
    private readonly IValidator<CreateAccountRequestDTO> _validator;
    private readonly IStringHasher _hasher;

    public RegisterService(IRepository<RegisterUser> userRepository , IValidator<CreateAccountRequestDTO> validator , IStringHasher hasher)
    {
        _userRepository = userRepository;
        _validator = validator;
        _hasher = hasher;
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
            PasswordHash = _hasher.HashToSha256(requestDto.Password , salt),
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