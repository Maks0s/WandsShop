using Application.Authentication.Common;
using Application.Common.CQRS;
using Application.Common.Interfaces.Auth;
using Domain.Common.DomainErrors.AppUsers;
using Domain.Entities;
using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Commands.Register
{
    public class RegisterUserCommandHandler
        : ICommandHandler<RegisterUserCommand, AuthResult?>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<ErrorOr<AuthResult?>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var createdUser = await _userManager.FindByEmailAsync(command.Email);

            if(createdUser != null)
            {
                return Errors.AppUsers.NotUniqueEmail(command.Email);
            }

            var newUser = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = command.Email,
                UserName = command.UserName
            };

            await _userManager.CreateAsync(newUser, command.Password);

            var jwt = _jwtGenerator.GenerateJwt(
                        newUser.Id,
                        newUser.UserName,
                        newUser.Email
                        );

            var authResult = new AuthResult(
                newUser.Id,
                newUser.Email,
                newUser.UserName,
                jwt
                );

            return authResult;
        }
    }
}
