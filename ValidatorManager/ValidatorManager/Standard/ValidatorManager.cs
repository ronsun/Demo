using ValidatorManager.Standard.Validators;

namespace ValidatorManager.Standard
{
    public class ValidatorManager
    {
        public bool BasicValidation(ValidateContext context)
        {
            var amountValidator = new AmountValidator();
            var emailValidator = new EmailValidator();

            Validator rootValidator = amountValidator;
            amountValidator.NextValidator = emailValidator;

            return rootValidator.Validate(context);
        }

        public bool FullValidation(ValidateContext context)
        {
            var amountValidator = new AmountValidator();
            var emailValidator = new EmailValidator();
            var countryValidator = new CountryValidator();

            Validator rootValidator = amountValidator;
            amountValidator.NextValidator = emailValidator;
            emailValidator.NextValidator = countryValidator;

            return rootValidator.Validate(context);
        }
    }
}
