using Application.Wands.Commands.Create;
using Domain.Entities;
using Domain.Common.DomainErrors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Application.Common.CQRS;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.Behaviors
{
    public class ValidationBehavion<TRequest, TResponse>
        : IPipelineBehavior<TRequest, ErrorOr<TResponse>>
        where TRequest : ICommand<TResponse>

    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavion(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<TResponse>> Handle(TRequest request, 
            RequestHandlerDelegate<ErrorOr<TResponse>> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var validationErrors = validationResult.Errors
                    .ConvertAll(error =>
                    Errors.Wands.NotValid(
                        error.PropertyName,
                        error.ErrorMessage));

            return validationErrors;
        }

    }
}
