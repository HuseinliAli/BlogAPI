using Application.Features.Auth.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Auth.Validators;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(lc => lc.UserRegisterDto.FirstName).NotEmpty().MaximumLength(100);

        RuleFor(lc => lc.UserRegisterDto.LastName).NotEmpty().MaximumLength(100);

        RuleFor(lc => lc.UserRegisterDto.Email).NotEmpty().EmailAddress().MaximumLength(100);

        RuleFor(lc => lc.UserRegisterDto.Password).NotEmpty().MinimumLength(3).MaximumLength(100);     
    }
    public override ValidationResult Validate(ValidationContext<RegisterCommand> context)
    {
        return context.InstanceToValidate.UserRegisterDto is null ?
            new ValidationResult(new[] { new ValidationFailure("UserRegisterDto", "UserRegisterDto object is null") })
            : base.Validate(context);
    }
}
