namespace ValidatorManager.Standard.Validators
{
    public class CountryValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            if (context.Country == "Taiwan")
            {
                return NextValidator?.Validate(context) ?? true;
            }

            return false;
        }
    }
}
