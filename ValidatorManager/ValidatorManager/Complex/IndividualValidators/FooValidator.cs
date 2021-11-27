namespace ValidatorManager.Complex.IndividualValidators
{
    public class FooValidator : Validator
    {
        public override bool Validate(ValidateContext context)
        {
            return context.Foo == "Foo";
        }
    }
}
