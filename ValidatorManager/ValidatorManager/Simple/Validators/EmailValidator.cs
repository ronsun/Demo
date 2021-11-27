namespace ValidatorManager.Simple.Validators
{
    public class EmailValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            return context.Email == "ron.sun@mailserver.com";
        }
    }
}
