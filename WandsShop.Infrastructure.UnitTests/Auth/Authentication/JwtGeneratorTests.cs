using FluentAssertions;
using FluentAssertions.Execution;
using Infrastructure.Auth.Authentication;
using Infrastructure.Auth.Common.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Xunit;
using WandsShop.Infrastructure.UnitTests.Auth.Authentication.TestUtils.TestConstants;
using WandsShop.Infrastructure.UnitTests.Auth.TestUtils.DataDTO;
using WandsShop.Infrastructure.UnitTests.Auth.TestUtils.DataGeneration;
using NSubstitute;
using WandsShop.Infrastructure.UnitTests.Auth.Authentication.TestUtils.AssertionExtensions;

namespace WandsShop.Infrastructure.UnitTests.Auth.Authentication
{
    public class JwtGeneratorTests
    {
        private readonly JwtGenerator _jwtGenerator;

        private readonly IOptions<JwtConfig> _mockIOptionsJwtConfig;
        private readonly JwtConfig _jwtConfig;
        private readonly ILogger<JwtGenerator> _mockLogger;

        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtGeneratorTests()
        {
            _jwtConfig = new JwtConfig()
            {
                Issuer = Constants.JwtConfig.Issuer,
                Audience = Constants.JwtConfig.Audience,
                SecretKey = Constants.JwtConfig.SecretKey
            };

            _mockIOptionsJwtConfig = Substitute.For<IOptions<JwtConfig>>();

            _mockIOptionsJwtConfig.Value
                .Returns(_jwtConfig);

            _mockLogger = Substitute.For<ILogger<JwtGenerator>>();

            _jwtGenerator = new JwtGenerator(
                _mockIOptionsJwtConfig,
                _mockLogger
                );

            _tokenHandler = new JwtSecurityTokenHandler();
        }

        [Theory]
        [ClassData(typeof(UserDataGeneration))]
        public async Task GenerateJwt_WithAnyData_ShouldReturnValidJwt(UserTestDataDTO userTestDataDTO)
        {
            //Arrange
            var tokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = _jwtConfig.Issuer,
                    ValidateIssuer = true,

                    ValidAudience = _jwtConfig.Audience,
                    ValidateAudience = true,

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes(_jwtConfig.SecretKey)
                                        ),
                    ValidateIssuerSigningKey = true
                };

            //Act
            var encodedJwt = _jwtGenerator.GenerateJwt(
                                    userTestDataDTO.Id,
                                    userTestDataDTO.UserName,
                                    userTestDataDTO.Email
                                    );

            //Assert
            var validationResult = await _tokenHandler.ValidateTokenAsync(
                                                        encodedJwt,
                                                        tokenValidationParameters
                                                        );

            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [ClassData(typeof(UserDataGeneration))]
        public void GenerateJwt_WithAnyData_ShouldGenerateCorrectPayload(UserTestDataDTO userTestDataDTO)
        {
            //Arrange

            //Act
            var encodedJwt = _jwtGenerator.GenerateJwt(
                                    userTestDataDTO.Id,
                                    userTestDataDTO.UserName,
                                    userTestDataDTO.Email
                                    );

            //Assert
            using var _ = new AssertionScope();

            var decodedJwt = _tokenHandler.ReadJwtToken(encodedJwt);

            decodedJwt.AssertPayloadWith(userTestDataDTO);   
        }
    }
}