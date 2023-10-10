using Application.Authentication.Common;
using Application.Common.CQRS;
using Application.Common.Interfaces.Auth;
using Domain.Common.DomainErrors.AppUsers;
using Domain.Entities;
using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Queries.Login
{
    public class LoginUserQueryHandler
        : IQueryHandler<LoginUserQuery, AuthResult?>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginUserQueryHandler(
            UserManager<AppUser> userManager,
            IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<ErrorOr<AuthResult?>> Handle(
            LoginUserQuery query,
            CancellationToken cancellationToken)
        {
            var registeredUser = await _userManager.FindByEmailAsync(query.Email);

            if(registeredUser is null)
            {
                return Errors.AppUsers.InvalidCredentials();
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(registeredUser, query.Password);

            if (!isPasswordCorrect)
            {
                return Errors.AppUsers.InvalidCredentials();
            }

            var jwt = _jwtGenerator.GenerateJwt(
                                    registeredUser.Id,
                                    registeredUser.UserName!,
                                    registeredUser.Email!
                                    );

            var authResult = new AuthResult(
                                registeredUser.Id,
                                registeredUser.Email!,
                                registeredUser.UserName!,
                                jwt
                                );

            return authResult;
        }
    }
}
