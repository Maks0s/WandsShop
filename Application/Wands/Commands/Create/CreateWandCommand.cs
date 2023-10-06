using Application.Common.CQRS;
using Domain.Entities;

namespace Application.Wands.Commands.Create
{
    public record CreateWandCommand(
        string Core,
        string Wood,
        decimal LengthInInches,
        string? Owner,
        string Description
        ) : ICommand<Wand?>;
}
