using FluentAssertions;
using System.IdentityModel.Tokens.Jwt;
using WandsShop.Infrastructure.UnitTests.Auth.TestUtils.DataDTO;
using WandsShop.Infrastructure.UnitTests.Auth.Authentication.TestUtils.TestConstants;

namespace WandsShop.Infrastructure.UnitTests.Auth.Authentication.TestUtils.AssertionExtensions
{
    public static class JwtAssertionExtensions
    {
        public static void AssertPayloadWith(this JwtSecurityToken decodedJwt, UserTestDataDTO userTestDataDTO)
        {
            decodedJwt.Subject.Should().Be(userTestDataDTO.Id);

            var uniqueNameCalim = decodedJwt.Claims.FirstOrDefault(claim =>
                                                    claim.Type.Equals(JwtRegisteredClaimNames.UniqueName)
                                                    );
            uniqueNameCalim.Should().NotBeNull();
            uniqueNameCalim?.Value.Should().Be(userTestDataDTO.UserName);

            var emailCalim = decodedJwt.Claims.FirstOrDefault(claim =>
                                                claim.Type.Equals(JwtRegisteredClaimNames.Email)
                                                );
            emailCalim.Should().NotBeNull();
            emailCalim?.Value.Should().Be(userTestDataDTO.Email);

            var expectedValidTo = DateTime.UtcNow.AddMinutes(5).ToShortTimeString();
            decodedJwt.ValidTo
                .ToShortTimeString()
                .Should().Be(expectedValidTo);

            var expectedIssuedAt = DateTime.UtcNow.ToShortTimeString();
            decodedJwt.IssuedAt
                .ToShortTimeString()
                .Should().Be(expectedIssuedAt);

            decodedJwt.Issuer.Should().Be(Constants.JwtConfig.Issuer);

            decodedJwt.Audiences.FirstOrDefault().Should().Be(Constants.JwtConfig.Audience);
        }
    }
}
