using CodeCube.FluentValidation.Validators;
using FluentValidation;

namespace CodeCube.FluentValidation
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> IsValidBSN<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new BSNValidator<T>());
        }

        public static IRuleBuilderOptions<T, string> IsValidDateTime<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new DateTimeValidator<T>());
        }

        public static IRuleBuilderOptions<T, string> DisallowHtml<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new HtmlValidator<T>(false));
        }

        public static IRuleBuilderOptions<T, string> AllowSanitizedHtml<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new HtmlValidator<T>(true));
        }
    }
}