using Application.Common.ApplicationErrors.Validation;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
    public class ValidationBehavion<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr

    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavion(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if(_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var validationErrors = validationResult.Errors
                                    .ConvertAll(error =>
                                        Errors.Validation.NotValid(
                                                error.PropertyName,
                                                error.ErrorMessage
                                                )
                                    );

            return (dynamic)validationErrors;
        }
    }
}
