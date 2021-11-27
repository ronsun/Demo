using System;
using Chain = ValidatorManager.Complex.ChainValidators;
using Individual = ValidatorManager.Complex.IndividualValidators;

namespace ValidatorManager.Complex
{
    public class ValidatorManager
    {
        public bool BasicValidation(Chain.ValidateContext chainContext, Individual.ValidateContext individualContext)
        {
            // do a validation
            var fooValidator = new Individual.FooValidator();
            if (!fooValidator.Validate(individualContext))
            {
                return false;
            }

            // do a serious of validation
            var amountValidator = new Chain.AmountValidator();
            var emailValidator = new Chain.EmailValidator();

            Chain.Validator rootValidator = amountValidator;
            amountValidator.NextValidator = emailValidator;

            Chain.ValidationResult chainValidatorResult = new Chain.ValidationResult();
            rootValidator.Validate(chainContext, chainValidatorResult);

            if (!chainValidatorResult.IsSuccess)
            {
                Console.WriteLine($"chainValidatorResult.ErrorMessage: {chainValidatorResult.ErrorMessage}");
            }

            return chainValidatorResult.IsSuccess;
        }

        public bool FullValidation(Chain.ValidateContext chainContext, Individual.ValidateContext individualContext)
        {
            // do a validation(s)
            var fooValidator = new Individual.FooValidator();
            if (!fooValidator.Validate(individualContext))
            {
                return false;
            }

            // do a serious of validation
            var amountValidator = new Chain.AmountValidator();
            var emailValidator = new Chain.EmailValidator();
            var countryValidator = new Chain.CountryValidator();

            Chain.Validator rootValidator = amountValidator;
            amountValidator.NextValidator = emailValidator;
            emailValidator.NextValidator = countryValidator;

            Chain.ValidationResult chainValidatorResult = new Chain.ValidationResult();
            rootValidator.Validate(chainContext, chainValidatorResult);

            if (!chainValidatorResult.IsSuccess)
            {
                Console.WriteLine($"chainValidatorResult.ErrorMessage: {chainValidatorResult.ErrorMessage}");
                return false;
            }

            // do another validaion(s)
            var barValidator = new Individual.BarValidator();
            return barValidator.Validate(individualContext);
        }
    }
}
