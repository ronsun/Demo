namespace ValidatorManager.Simple.Validators
{
    public abstract class Validator
    {
        public abstract bool Validate(ValidateContext context);
    }
}
