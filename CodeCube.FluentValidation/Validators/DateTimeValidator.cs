using System;
using FluentValidation;
using FluentValidation.Validators;

namespace CodeCube.FluentValidation.Validators
{
    public class DateTimeValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "DateTimeValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => ErrorConstants.EN.InvalidDate;

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return DateTime.TryParse(value, out var theDateTime) && theDateTime > DateTime.MinValue;
        }
    }
}