using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Common.DTO.WandDTOs.Requests
{
    public record UpdateWandRequest(
        string Core,
        string Wood,
        decimal LengthInInches,
        string? Owner,
        string Description
    );
}
