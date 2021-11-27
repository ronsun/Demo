namespace ValidatorManager.Simple.Validators
{
    public class AmountValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            return context.Amount > 10;
        }
    }
}
