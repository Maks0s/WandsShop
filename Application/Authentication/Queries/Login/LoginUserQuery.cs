using Application.Authentication.Common;
using Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Queries.Login
{
    public record LoginUserQuery(
        string Email,
        string Password
        ) : IQuery<AuthResult?>;
}
