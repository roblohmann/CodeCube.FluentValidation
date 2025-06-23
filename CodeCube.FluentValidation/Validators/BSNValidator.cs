using CodeCube.Core.Helpers;
using FluentValidation;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class BSNValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "BSNValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => ErrorConstants.NL.OngeldigBSN;

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return BSNHelper.Elfproef(value);
            }

            return false;
        }
    }
}