using FluentValidation;
using Application.Common.CustomValidators.AppUser;

namespace Application.Authentication.Commands.Register
{
    public class RegisterUserCommandValidator 
        : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(ruc => ruc.Email)
                .EmailAddress();

            RuleFor(ruc => ruc.UserName)
                .NotEmpty()
                .NotNull();

            RuleFor(ruc => ruc.Password)
                .PasswordValidation();
        }
    }
}
