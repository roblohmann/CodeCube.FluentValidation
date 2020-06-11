using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class HtmlValidator : PropertyValidator
    {
        private readonly bool _allowSanitizedHtml;

        public HtmlValidator(bool allowSanitizedHtml = false) : base(ErrorConstants.EN.InvalidValue)
        {
            _allowSanitizedHtml = allowSanitizedHtml;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return true;

            var potentialyHtmlValue = context.PropertyValue as string;
            if (string.IsNullOrWhiteSpace(potentialyHtmlValue)) return true;

            bool containsHtml = Regex.IsMatch(potentialyHtmlValue, @"<[^>]*?>");
            return containsHtml && _allowSanitizedHtml;
        }
    }
}