using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.CustomValidators.Wand
{
    public static class OwnerValidator
    {
        public static IRuleBuilderOptions<T, string> IfExistsValidateLength<T>(
            this IRuleBuilderInitial<T, string> ruleBuilder,
            int minLength,
            int maxLength)
        {
            return ruleBuilder
                .Length(minLength, maxLength)
                .WithMessage("If Owner exsists, " +
                "the owner's name should be between: " +
                "{MinLength} and {MaxLength} characters. " +
                "You've entered {TotalLength}");
        }
    }
}
