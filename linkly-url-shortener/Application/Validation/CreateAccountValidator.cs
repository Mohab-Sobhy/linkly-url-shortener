using System.ComponentModel.DataAnnotations;
using FluentValidation;
using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;

namespace linkly_url_shortener.Application.Validation;

public class CreateAccountValidator : AbstractValidator<CreateAccountRequestDTO>
{
    public CreateAccountValidator(IRegisterUserRepository _registerUserRepository)
    {
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email is invalid")
            .MustAsync(async(email, _)=>
                !await _registerUserRepository.ExistsByEmailAsync(email))
            .WithMessage("Email already registered");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters long")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .Must(username => !username.Contains("@"))
            .WithMessage("Username cannot contain '@'")
            .MustAsync(async (username, _) =>
                !await _registerUserRepository.ExistsByUsernameAsync(username))
            .WithMessage("Username already taken");
    }
    
}