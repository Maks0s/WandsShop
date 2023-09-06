using ErrorOr;
using MediatR;

namespace Application.Common.CQRS
{
    public interface ICommandHandler<TCommand, TResponse> 
        : IRequestHandler<TCommand, ErrorOr<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
