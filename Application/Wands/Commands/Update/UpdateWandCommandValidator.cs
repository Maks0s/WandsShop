using Application.Common.CustomValidators.Wand;
using FluentValidation;

namespace Application.Wands.Commands.Update
{
    public class UpdateWandCommandValidator
        : AbstractValidator<UpdateWandCommand>
    {
        public UpdateWandCommandValidator()
        {
            RuleFor(uwc => uwc.Core)
                .FillingAndLengthValidationBetween(3, 25);

            RuleFor(uwc => uwc.Wood)
                .FillingAndLengthValidationBetween(3, 15);

            RuleFor(uwc => uwc.LengthInInches)
                .MustBeValidLengthBetween(6, 17);

            RuleFor(uwc => uwc.Owner)
                .IfExistsValidateLength(5, 80)
                .When(uwc => uwc.Owner != null);

            RuleFor(uwc => uwc.Description)
                .FillingAndLengthValidationBetween(30, 150);
        }
    }
}
