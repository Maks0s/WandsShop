using Application.Authentication.Common;
using Application.Common.CQRS;

namespace Application.Authentication.Commands.Register
{
    public record RegisterUserCommand(
        string Email,
        string UserName,
        string Password
        ) : ICommand<AuthResult?>;
}
