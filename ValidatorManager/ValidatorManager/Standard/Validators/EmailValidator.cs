namespace ValidatorManager.Standard.Validators
{
    public class EmailValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            if (context.Email == "ron.sun@mailserver.com")
            {
                return NextValidator?.Validate(context) ?? true;
            }

            return false;
        }
    }
}
