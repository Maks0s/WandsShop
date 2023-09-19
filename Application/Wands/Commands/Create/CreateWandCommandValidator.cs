using Application.Common.CustomValidators.Wand;
using FluentValidation;

namespace Application.Wands.Commands.Create
{
    public class CreateWandCommandValidator 
        : AbstractValidator<CreateWandCommand>
    {
        public CreateWandCommandValidator()
        {
            RuleFor(cwc => cwc.Core)
                .FillingAndLengthValidationBetween(3, 25);

            RuleFor(cwc => cwc.Wood)
                .FillingAndLengthValidationBetween(3, 15);

            RuleFor(cwc => cwc.LengthInInches)
                .MustBeValidLengthBetween(6, 17);

            RuleFor(cwc => cwc.Owner)
                .IfExistsValidateLength(5, 80)
                .When(uwc => !string.IsNullOrEmpty(uwc.Owner));

            RuleFor(cwc => cwc.Description)
                .FillingAndLengthValidationBetween(30, 150);
        }
    }
}
