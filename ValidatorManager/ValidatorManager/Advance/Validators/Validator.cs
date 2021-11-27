namespace ValidatorManager.Advance.Validators
{
    public abstract class Validator
    {
        public Validator NextValidator { get; set; }

        public bool Validate(ValidateContext context)
        {
            bool isValid = DerivedValidation(context);
            if (isValid)
            {
                return NextValidator?.Validate(context) ?? true;
            }

            return false;
        }

        protected abstract bool DerivedValidation(ValidateContext context);
    }
}
