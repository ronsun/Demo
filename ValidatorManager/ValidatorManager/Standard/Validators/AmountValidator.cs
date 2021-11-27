namespace ValidatorManager.Standard.Validators
{
    public class AmountValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            if (context.Amount > 10)
            {
                return NextValidator?.Validate(context) ?? true;
            }

            return false;
        }
    }
}
