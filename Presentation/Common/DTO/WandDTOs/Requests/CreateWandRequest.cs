namespace Presentation.Common.DTO.WandDTOs.Requests
{
    public record CreateWandRequest(
        string Core,
        string Wood,
        decimal LengthInInches,
        string? Owner,
        string Description
        );
}
