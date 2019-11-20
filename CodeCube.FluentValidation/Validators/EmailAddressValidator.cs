using CodeCube.Core.Helpers;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class EmailAddressValidator<T> : PropertyValidator
    {
        private readonly bool IsMandatory;

        public EmailAddressValidator(bool isMandatory) : base(ErrorConstants.EN.InvalidEmailAddress)
        {
            IsMandatory = isMandatory;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (!IsMandatory) return true;

            var emailAddress = context.PropertyValue as string;
            if (string.IsNullOrWhiteSpace(emailAddress)) return false;

            return RegexUtilities.IsValidEmail(emailAddress);
        }
    }
}