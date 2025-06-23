using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class HtmlValidator<T> : PropertyValidator<T, string>
    {
        private readonly bool _allowSanitizedHtml;

        public HtmlValidator(bool allowSanitizedHtml = false)
        {
            _allowSanitizedHtml = allowSanitizedHtml;
        }

        public override string Name => "HtmlValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => ErrorConstants.EN.InvalidValue;

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            bool containsHtml = Regex.IsMatch(value, @"<[^>]*?>");
            return !containsHtml || _allowSanitizedHtml;
        }
    }
}