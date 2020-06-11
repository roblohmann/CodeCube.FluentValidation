using CodeCube.FluentValidation.Validators;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Validators;
using Xunit;

namespace CodeCube.FluentValidation.Test
{
    public class FluentValidatorTestObject
    {
        public object Value { get; set; }
    }

    public class HtmlValidatorTest
    {
        [Fact]
        public void StringWithHtml_ShouldReturnError_HtmlDisallowed()
        {
            //Setup
            const bool allowSanitizedHtml = false;
            var validator = new HtmlValidator(allowSanitizedHtml);
            var fluentValidatorTestObject = new FluentValidatorTestObject { Value = "Dit is een <b>test</b>" };

            var selector = ValidatorOptions.ValidatorSelectors.DefaultValidatorSelectorFactory();
            var context = new ValidationContext(fluentValidatorTestObject, new PropertyChain(), selector);
            var propertyValidatorContext = new PropertyValidatorContext(context, PropertyRule.Create<FluentValidatorTestObject, string>(t => t.Value.ToString()), "Value");

            //Act
            var results = validator.Validate(propertyValidatorContext);

            //Assert
            Assert.NotEmpty(results);
        }

        [Fact]
        public void StringWithJavascript_ShouldReturnError_HtmlDisallowed()
        {
            //Setup
            const bool allowSanitizedHtml = false;
            var validator = new HtmlValidator(allowSanitizedHtml);
            var fluentValidatorTestObject = new FluentValidatorTestObject { Value = "Dit is een stukje javascript: '><script>alert('hoi');</script>" };

            var selector = ValidatorOptions.ValidatorSelectors.DefaultValidatorSelectorFactory();
            var context = new ValidationContext(fluentValidatorTestObject, new PropertyChain(), selector);
            var propertyValidatorContext = new PropertyValidatorContext(context, PropertyRule.Create<FluentValidatorTestObject, string>(t => t.Value.ToString()), "Value");

            //Act
            var results = validator.Validate(propertyValidatorContext);

            //Assert
            Assert.NotEmpty(results);
        }

        [Fact]
        public void StringWithHtml_ShouldReturnError_HtmlAllowed()
        {
            //Setup
            const bool allowSanitizedHtml = true;
            var validator = new HtmlValidator(allowSanitizedHtml);
            var fluentValidatorTestObject = new FluentValidatorTestObject { Value = "Dit is een <b>test</b>" };

            var selector = ValidatorOptions.ValidatorSelectors.DefaultValidatorSelectorFactory();
            var context = new ValidationContext(fluentValidatorTestObject, new PropertyChain(), selector);
            var propertyValidatorContext = new PropertyValidatorContext(context, PropertyRule.Create<FluentValidatorTestObject, string>(t => t.Value.ToString()), "Value");

            //Act
            var results = validator.Validate(propertyValidatorContext);

            //Assert
            Assert.Empty(results);
        }
    }
}
