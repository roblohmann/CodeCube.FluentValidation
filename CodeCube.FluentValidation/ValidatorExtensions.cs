using System;
using CodeCube.FluentValidation.Validators;
using FluentValidation;

namespace CodeCube.FluentValidation
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> IsValidBSN<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new BSNValidator<T>());
        }

        public static IRuleBuilder<T, DateTime> IsValidDateTime<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new DateTimeValidator<T>());
        }

        public static IRuleBuilder<T, string> IsValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder, bool isMandatory)
        {
            return ruleBuilder.SetValidator(new EmailAddressValidator<T>(isMandatory));

        }

        public static IRuleBuilder<T, string> IsValidString<T>(this IRuleBuilder<T, string> ruleBuilder, bool isHtmlAllowed)
        {
            return ruleBuilder.SetValidator(new HtmlValidator<T>(isHtmlAllowed));
        }
    }
}