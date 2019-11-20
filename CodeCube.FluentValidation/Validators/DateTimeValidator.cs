using System;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class DateTimeValidator<T> : PropertyValidator
    {

        public DateTimeValidator() : base(ErrorConstants.EN.InvalidDate)
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return false;
            var datetimeAsString = context.PropertyValue as string;
            
            if (string.IsNullOrWhiteSpace(datetimeAsString)) return false;

            return DateTime.TryParse(datetimeAsString, out DateTime theDateTime) && theDateTime > DateTime.MinValue;
        }
    }
}