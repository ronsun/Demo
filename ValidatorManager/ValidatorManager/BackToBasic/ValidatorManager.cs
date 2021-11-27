namespace ValidatorManager.BackToBasic
{
    public class ValidatorManager
    {
        private Validator _validator = new Validator();
        private AnotherValidator _anotherValidator = new AnotherValidator();

        public bool BasicToBasicValidation(decimal amount, string email, string foo, string bar)
        {
            var passAll = _validator.AmountValidate(amount) &&
                          _validator.EmailValidate(email);

            var passAny = _anotherValidator.FooValidate(foo) ||
                          _anotherValidator.BarValidate(bar);

            return passAll && passAny;
        }
    }
}
