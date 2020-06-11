using CodeCube.Core.Helpers;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class BSNValidator<T> : PropertyValidator
    {

        public BSNValidator() : base(ErrorConstants.NL.OngeldigBSN)
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var bsn = context.PropertyValue as string;

            if (!string.IsNullOrWhiteSpace(bsn))
            {
                return BSNHelper.Elfproef(bsn);
            }

            return false;
        }
    }
}