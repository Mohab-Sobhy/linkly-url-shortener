using FluentValidation;
using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces;
using linkly_url_shortener.Domain.Interfaces.Repositories;

namespace linkly_url_shortener.Application.Services;

public class AuthenticationService
{
    private readonly IRegisterUserRepository _repository;
    private readonly IValidator<AuthenticateUserRequestDTO> _validator;
    private readonly IStringHasher _hasher;
    private readonly ITokenGenerator _tokenGenerator;
    
    public AuthenticationService(
        IRegisterUserRepository repository, 
        IValidator<AuthenticateUserRequestDTO> validator,
        IStringHasher hasher,
        ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _validator = validator;
        _hasher = hasher;
        _tokenGenerator = tokenGenerator;
    }
    
    public async Task<string?> AuthenticateAsync(AuthenticateUserRequestDTO request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        RegisterUser? user = null;
        
        if( request.Identifier.Contains('@') )
        {
            user = await _repository.GetByEmailAsync(request.Identifier);
        }
        else
        {
            user = await _repository.GetByUsernameAsync(request.Identifier);
        }

        if (user == null) 
            return null;

        var hashedPassword = _hasher.HashToSha256(request.Password, user.PasswordSalt);
        
        if( hashedPassword.Length != user.PasswordHash.Length )
            return null;

        for (int i = 0; i < hashedPassword.Length; i++)
        {
            if (hashedPassword[i] != user.PasswordHash[i])
            {
                return null;
            }
        }

        _repository.UpdateLastLoginAsync(user);
        
        return _tokenGenerator.GenerateJwtToken(user);
    }
    
}
