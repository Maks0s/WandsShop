using FluentValidation;

namespace Application.Wands.Commands.Create
{
    public class CreateWandCommandValidator 
        : AbstractValidator<CreateWandCommand>
    {
        public CreateWandCommandValidator()
        {
            RuleFor(cwc => cwc.Core)
                .NotEmpty()
                .Length(3, 25);

            RuleFor(cwc => cwc.Wood)
                .NotEmpty()
                .Length(3, 15);

            RuleFor(cwc => cwc.LengthInInches)
                .NotEmpty()
                .Must(lengthInInches =>
                    lengthInInches > 5 &&
                    lengthInInches < 18
                    );

            RuleFor(cwc => cwc.Owner)
                .Length(5, 80);

            RuleFor(cwc => cwc.Description)
                .NotEmpty()
                .Length(30, 150);
        }
    }
}
