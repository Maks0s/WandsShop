namespace Presentation.Common.DTO.AppUserDTOs.Requests
{
    public record RegisterRequest(
        string Email,
        string UserName,
        string Password
        );
}
