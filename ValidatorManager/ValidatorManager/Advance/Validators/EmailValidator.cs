namespace ValidatorManager.Advance.Validators
{
    public class EmailValidator : Validator
    {
        protected override bool DerivedValidation(ValidateContext context)
        {
            return context.Email == "ron.sun@mailserver.com";
        }
    }
}
