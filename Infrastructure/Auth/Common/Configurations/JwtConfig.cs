
namespace Infrastructure.Auth.Common.Configurations
{
    public class JwtConfig
    {
        public const string SectionName = "JwtConfig";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
