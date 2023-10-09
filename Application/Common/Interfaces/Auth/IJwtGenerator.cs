using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Auth
{
    public interface IJwtGenerator
    {
        public string GenerateJwt(string id, string userName, string email);
    }
}
