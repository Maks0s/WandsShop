using Application.Wands.Commands.Create;
using Domain.Entities;
using Domain.Common.DomainErrors;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
    public class ValidationBehavior
        : IPipelineBehavior<CreateWandCommand, ErrorOr<Wand?>>
    {
        private readonly IValidator<CreateWandCommand> _validator;

        public ValidationBehavior(IValidator<CreateWandCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<Wand?>> Handle(
            CreateWandCommand request, 
            RequestHandlerDelegate<ErrorOr<Wand?>> next, 
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if(validationResult.IsValid)
            {
                var result = await next();

                return result;
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
