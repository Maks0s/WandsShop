using ErrorOr;
using System.Net;

namespace Domain.Common.DomainErrors.AppUsers
{
    public static class Errors
    {
        public static class AppUsers
        {
            public static Error NotUniqueEmail(string email) =>
                Error.Custom(
                    (int)HttpStatusCode.BadRequest,
                    "Email already exists",
                    $"User with email: {email} is alredy registered"
                    );
        }
    }
}
