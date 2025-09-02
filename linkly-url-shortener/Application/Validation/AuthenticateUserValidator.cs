using FluentValidation;
using linkly_url_shortener.Application.DTO;

namespace linkly_url_shortener.Application.Validation;

public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserRequestDTO>
{
    public AuthenticateUserValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x.Identifier)
            .NotNull().WithMessage("Please provide either a username or an email address.");
    }
}