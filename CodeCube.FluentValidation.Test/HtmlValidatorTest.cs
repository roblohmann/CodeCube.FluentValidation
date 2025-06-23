using CodeCube.FluentValidation.Validators;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.TestHelper;
using FluentValidation.Validators;
using Xunit;

namespace CodeCube.FluentValidation.Test
{
    public class FluentValidatorTestObject
    {
        public string Value { get; set; }
    }

// Wrapper-validator om onze custom HtmlValidator te testen
    public class TestHtmlValidator : AbstractValidator<FluentValidatorTestObject>
    {
        public TestHtmlValidator(bool allowSanitizedHtml)
        {
            RuleFor(x => x.Value).SetValidator(new HtmlValidator<FluentValidatorTestObject>(allowSanitizedHtml));
        }
    }

    public class HtmlValidatorTest
    {
        [Fact]
        public void StringWithHtml_ShouldReturnError_HtmlDisallowed()
        {
            var validator = new TestHtmlValidator(allowSanitizedHtml: false);
            var testObject = new FluentValidatorTestObject { Value = "Dit is een <b>test</b>" };

            var result = validator.TestValidate(testObject);

            result.ShouldHaveValidationErrorFor(x => x.Value);
        }

        [Fact]
        public void StringWithJavascript_ShouldReturnError_HtmlDisallowed()
        {
            var validator = new TestHtmlValidator(allowSanitizedHtml: false);
            var testObject = new FluentValidatorTestObject { Value = "Dit is een stukje javascript: '><script>alert('hoi');</script>" };

            var result = validator.TestValidate(testObject);

            result.ShouldHaveValidationErrorFor(x => x.Value);
        }

        [Fact]
        public void StringWithHtml_ShouldNotReturnError_HtmlAllowed()
        {
            var validator = new TestHtmlValidator(allowSanitizedHtml: true);
            var testObject = new FluentValidatorTestObject { Value = "Dit is een <b>test</b>" };

            var result = validator.TestValidate(testObject);

            result.ShouldNotHaveValidationErrorFor(x => x.Value);
        }
    }
}
