namespace ValidatorManager.BackToBasic
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
    }
}
