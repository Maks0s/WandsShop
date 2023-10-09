namespace Application.Authentication.Common
{
    public record AuthResult(
        string Id,
        string Email,
        string UserName,
        string Jwt
        );
}
