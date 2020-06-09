using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class HtmlValidator<T> : PropertyValidator
    {
        private readonly bool IsHtmlAllowed;

        public HtmlValidator(bool isHtmlAllowed = false) : base(ErrorConstants.EN.InvalidValue)
        {
            IsHtmlAllowed = isHtmlAllowed;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return true;

            var potentialyHtmlValue = context.PropertyValue as string;
            if (string.IsNullOrWhiteSpace(potentialyHtmlValue)) return true;

            bool containsHtml = Regex.IsMatch(potentialyHtmlValue, @"<[^>]*?>");
            return containsHtml && IsHtmlAllowed;
        }
    }
}