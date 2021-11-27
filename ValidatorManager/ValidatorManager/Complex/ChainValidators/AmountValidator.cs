namespace ValidatorManager.Complex.ChainValidators
{
    public class AmountValidator : Validator
    {
        protected override bool DerivedValidation(ValidateContext context)
        {
            return context.Amount > 10;
        }
    }
}
