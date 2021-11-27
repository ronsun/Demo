namespace ValidatorManager.Complex.ChainValidators
{
    public abstract class Validator
    {
        public Validator NextValidator { get; set; }

        public void Validate(ValidateContext context, ValidationResult result)
        {
            bool isValid = DerivedValidation(context);
            if (isValid)
            {
                if (NextValidator == null)
                {
                    result.IsSuccess = true;
                }
                else
                {
                    NextValidator.Validate(context, result);
                }

                return;
            }

            result.IsSuccess = false;
            result.ErrorMessage = $"Violate validator {GetType().Name}";
            return;
        }

        protected abstract bool DerivedValidation(ValidateContext context);
    }
}
