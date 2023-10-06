using Application.Common.CQRS;

namespace Application.Wands.Commands.Delete
{
    public record DeleteWandCommand(int Id) 
        : ICommand<ErrorOr.Deleted>;
}
