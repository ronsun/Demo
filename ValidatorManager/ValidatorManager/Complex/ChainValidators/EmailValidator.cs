namespace ValidatorManager.Complex.ChainValidators
{
    public class EmailValidator : Validator
    {
        protected override bool DerivedValidation(ValidateContext context)
        {
            return context.Email == "ron.sun@mailserver.com";
        }
    }
}
