namespace Presentation.Common.DTO.AppUserDTOs.Responses
{
    public record AuthResponse(
        string Id,
        string Email,
        string UserName,
        string Jwt
        );
}
