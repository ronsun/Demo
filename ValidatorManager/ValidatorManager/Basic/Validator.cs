using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorManager.Basic
{
    public class Validator
    {
        public bool AmountValidate(decimal amount)
        {
            return amount > 10;
        }

        public bool EmailValidate(string email)
        {
            return email == "ron.sun@mailserver.com";
        }

        public bool CountryValidate(string country)
        {
            return country == "Taiwan";
        }
    }
}
