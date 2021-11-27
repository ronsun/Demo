namespace ValidatorManager.Advance.Validators
{
    public class AmountValidator : Validator
    {
        protected override bool DerivedValidation(ValidateContext context)
        {
            return context.Amount > 10;
        }
    }
}
