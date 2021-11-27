using System.Collections.Generic;
using ValidatorManager.Simple.Validators;

namespace ValidatorManager.Simple
{
    public class ValidatorManager
    {
        public bool BasicValidation(ValidateContext context)
        {
            List<Validator> valodators = new List<Validator>()
            {
                new AmountValidator(),
                new EmailValidator()
            };

            return Validate(valodators, context);
        }

        public bool FullValidation(ValidateContext context)
        {
            List<Validator> valodators = new List<Validator>()
            {
                new AmountValidator(),
                new EmailValidator(),
                new CountryValidator()
            };

            return Validate(valodators, context);
        }

        private bool Validate(List<Validator> valodators, ValidateContext context)
        {
            foreach (var validator in valodators)
            {
                bool isValid = validator.Validate(context);
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
