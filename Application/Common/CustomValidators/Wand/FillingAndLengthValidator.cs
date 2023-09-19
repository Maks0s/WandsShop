using FluentValidation;

namespace Application.Common.CustomValidators.Wand
{
    public static class FillingAndLengthValidator
    {
        public static IRuleBuilderOptions<T, string> FillingAndLengthValidationBetween<T>(
            this IRuleBuilderInitial<T, string> ruleBuilder,
            int minLength,
            int maxLength)
        {
            return ruleBuilder
                    .NotEmpty()
                    .NotNull()
                    .Length(minLength, maxLength)
                    .WithMessage("{PropertyName} must be between " +
                    "{MinLength} and {MaxLength} characters. " +
                    "You've entered {TotalLength}.");
        }
    }
}
