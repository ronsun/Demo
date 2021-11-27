namespace ValidatorManager.Complex.IndividualValidators
{
    public class BarValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            return context.Bar == "Bar";
        }
    }
}
