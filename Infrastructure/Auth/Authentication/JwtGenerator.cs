using Application.Common.Interfaces.Auth;
using Infrastructure.Auth.Common.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Auth.Authentication
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly JwtConfig _jwtConfig;
        private readonly ILogger<JwtGenerator> _logger;

        public JwtGenerator(IOptions<JwtConfig> jwtConfig, ILogger<JwtGenerator> logger)
        {
            _jwtConfig = jwtConfig.Value;
            _logger = logger;
        }

        public string GenerateJwt(string id, string userName, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, id),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            var hashedSecretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfig.SecretKey)
                );


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    hashedSecretKey,
                    SecurityAlgorithms.HmacSha256
                ),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(jwt);
        }
    }
}
