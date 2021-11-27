using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorManager.Basic
{
    public class ValidatorManager
    {
        private Validator _validator = new Validator();

        public bool BasicValidation(decimal amount, string email)
        {
            List<Func<bool>> valodationMethods = new List<Func<bool>>()
            {
                () => _validator.AmountValidate(amount),
                () => _validator.EmailValidate(email)
            };

            return Validate(valodationMethods);
        }

        public bool FullValidation(decimal amount, string email, string country)
        {
            List<Func<bool>> valodationMethods = new List<Func<bool>>()
            {
                () => _validator.AmountValidate(amount),
                () => _validator.EmailValidate(email),
                () => _validator.CountryValidate(country)
            };

            return Validate(valodationMethods);
        }

        private bool Validate(List<Func<bool>> valodationMethods)
        {
            foreach (var method in valodationMethods)
            {
                bool isValid = method();
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
