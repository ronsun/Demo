namespace ValidatorManager.Complex.IndividualValidators
{
    public abstract class Validator
    {
        public abstract bool Validate(ValidateContext context);
    }
}
