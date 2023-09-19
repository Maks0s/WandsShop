using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Common.DTO.Request
{
    public record UpdateWandRequest(
        string Core,
        string Wood,
        decimal LengthInInches,
        string? Owner,
        string Description
    );
}
