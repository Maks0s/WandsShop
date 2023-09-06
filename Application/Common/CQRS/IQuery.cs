using ErrorOr;
using MediatR;

namespace Application.Common.CQRS
{
    public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
    {
    }
}
