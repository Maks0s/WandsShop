using ErrorOr;
using MediatR;

namespace Application.Common.CQRS
{
    public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>>
    { 
    }
}
