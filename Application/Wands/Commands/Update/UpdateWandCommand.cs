using Application.Common.CQRS;

namespace Application.Wands.Commands.Update
{
    public record UpdateWandCommand(
        string Core,
        string Wood,
        decimal LengthInInches,
        string? Owner,
        string Description
        ) : ICommand<ErrorOr.Updated>
    {
        public int Id { get; set; }
    }
}
