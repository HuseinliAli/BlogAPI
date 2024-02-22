using Application.Features.Auth.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Auth.Validators;
public sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(lc=>lc.UserLoginDto.Email).NotEmpty().EmailAddress().MaximumLength(100);

        RuleFor(lc => lc.UserLoginDto.Password).NotEmpty().MinimumLength(3).MaximumLength(100);
    }
}