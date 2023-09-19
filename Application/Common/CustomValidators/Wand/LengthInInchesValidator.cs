using FluentValidation;

namespace Application.Common.CustomValidators.Wand
{
    public static class LengthInInchesValidator
    {
        public static IRuleBuilderOptions<T, decimal> MustBeValidLengthBetween<T>(
            this IRuleBuilderInitial<T, decimal> ruleBuilder,
            int minLength,
            int maxLength)
        {
            return ruleBuilder
                .InclusiveBetween(minLength, maxLength)
                .WithMessage("{PropertyName} must be between " +
                "{From} and {To}. " +
                "You've entered {PropertyValue}");
        }
    }
}
