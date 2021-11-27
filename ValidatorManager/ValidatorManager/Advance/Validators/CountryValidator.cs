namespace ValidatorManager.Advance.Validators
{
    public class CountryValidator : Validator
    {
        protected override bool DerivedValidation(ValidateContext context)
        {
            return context.Country == "Taiwan";
        }
    }
}
