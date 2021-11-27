using System;

namespace ValidatorManager
{
    public class Tests
    {
        private decimal validAmount = 11;
        private decimal invalidAmount = 10;

        private string validEmail = "ron.sun@mailserver.com";
        private string invalidEmail = "a";

        private string validCountry = "Taiwan";
        private string invalidCountry = "a";

        private string validFoo = "Foo";
        private string invalidFoo = "a";

        private string validBar = "Bar";
        private string invalidBar = "a";

        #region BasicTest

        public void BasicTest()
        {
            var manager = new Basic.ValidatorManager();

            Console.WriteLine($"Basic.ValidatorManager.BasicValidation() => ");
            BasicTest_BasicValidation(invalidAmount, validEmail, false);
            BasicTest_BasicValidation(validAmount, invalidEmail, false);
            BasicTest_BasicValidation(validAmount, validEmail, true);

            Console.WriteLine();

            Console.WriteLine($"Basic.ValidatorManager.FullValidation() => ");
            BasicTest_FullValidation(invalidAmount, validEmail, validCountry, false);
            BasicTest_FullValidation(validAmount, invalidEmail, validCountry, false);
            BasicTest_FullValidation(validAmount, validEmail, invalidCountry, false);
            BasicTest_FullValidation(validAmount, validEmail, validCountry, true);

            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine();
        }

        private void BasicTest_BasicValidation(decimal amount, string email, bool expected)
        {
            var actual = new Basic.ValidatorManager().BasicValidation(amount, email);
            Assert(expected, actual);
        }

        private void BasicTest_FullValidation(decimal amount, string email, string country, bool expected)
        {
            var actual = new Basic.ValidatorManager().FullValidation(amount, email, country);
            Assert(expected, actual);
        }

        #endregion

        #region SimpleTest

        public void SimpleTest()
        {
            var manager = new Simple.ValidatorManager();

            Console.WriteLine($"Simple.ValidatorManager.BasicValidation() => ");
            SimpleTest_BasicValidation(invalidAmount, validEmail, false);
            SimpleTest_BasicValidation(validAmount, invalidEmail, false);
            SimpleTest_BasicValidation(validAmount, validEmail, true);

            Console.WriteLine();

            Console.WriteLine($"Simple.ValidatorManager.FullValidation() => ");
            SimpleTest_FullValidation(invalidAmount, validEmail, validCountry, false);
            SimpleTest_FullValidation(validAmount, invalidEmail, validCountry, false);
            SimpleTest_FullValidation(validAmount, validEmail, invalidCountry, false);
            SimpleTest_FullValidation(validAmount, validEmail, validCountry, true);

            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine();
        }

        private void SimpleTest_BasicValidation(decimal amount, string email, bool expected)
        {
            var validationContext = new Simple.Validators.ValidateContext()
            {
                Amount = amount,
                Email = email
            };
            var actual = new Simple.ValidatorManager().BasicValidation(validationContext);
            Assert(expected, actual);
        }

        private void SimpleTest_FullValidation(decimal amount, string email, string country, bool expected)
        {
            var validationContext = new Simple.Validators.ValidateContext()
            {
                Amount = amount,
                Email = email,
                Country = country
            };
            var actual = new Simple.ValidatorManager().FullValidation(validationContext);
            Assert(expected, actual);
        }

        #endregion

        #region AdvanceTest

        public void AdvanceTest()
        {
            var manager = new Advance.ValidatorManager();

            Console.WriteLine($"Advance.ValidatorManager.BasicValidation() => ");
            AdvanceTest_BasicValidation(invalidAmount, validEmail, false);
            AdvanceTest_BasicValidation(validAmount, invalidEmail, false);
            AdvanceTest_BasicValidation(validAmount, validEmail, true);

            Console.WriteLine();

            Console.WriteLine($"Advance.ValidatorManager.FullValidation() => ");
            AdvanceTest_FullValidation(invalidAmount, validEmail, validCountry, false);
            AdvanceTest_FullValidation(validAmount, invalidEmail, validCountry, false);
            AdvanceTest_FullValidation(validAmount, validEmail, invalidCountry, false);
            AdvanceTest_FullValidation(validAmount, validEmail, validCountry, true);

            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine();
        }

        private void AdvanceTest_BasicValidation(decimal amount, string email, bool expected)
        {
            var validationContext = new Advance.Validators.ValidateContext()
            {
                Amount = amount,
                Email = email
            };
            var actual = new Advance.ValidatorManager().BasicValidation(validationContext);
            Assert(expected, actual);
        }

        private void AdvanceTest_FullValidation(decimal amount, string email, string country, bool expected)
        {
            var validationContext = new Advance.Validators.ValidateContext()
            {
                Amount = amount,
                Email = email,
                Country = country
            };
            var actual = new Advance.ValidatorManager().FullValidation(validationContext);
            Assert(expected, actual);
        }

        #endregion

        #region ComplexTest

        public void ComplexTest()
        {
            var manager = new Complex.ValidatorManager();

            Console.WriteLine($"Complex.ValidatorManager.BasicValidation() => ");
            ComplexTest_BasicValidation(invalidAmount, validEmail, validFoo, false);
            ComplexTest_BasicValidation(validAmount, invalidEmail, validFoo, false);
            ComplexTest_BasicValidation(validAmount, validEmail, invalidFoo, false);

            ComplexTest_BasicValidation(invalidAmount, invalidEmail, validFoo, false);
            ComplexTest_BasicValidation(invalidAmount, validEmail, invalidFoo, false);
            ComplexTest_BasicValidation(validAmount, invalidEmail, invalidFoo, false);

            ComplexTest_BasicValidation(invalidAmount, invalidEmail, invalidFoo, false);

            ComplexTest_BasicValidation(validAmount, validEmail, validFoo, true);

            Console.WriteLine();

            Console.WriteLine($"Complex.ValidatorManager.FullValidation() => ");

            // 1 invalid parameter
            ComplexTest_FullValidation(invalidAmount, validEmail, validCountry, validFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, invalidEmail, validCountry, validFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, validEmail, invalidCountry, validFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, validEmail, validCountry, invalidFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, validEmail, validCountry, validFoo, invalidBar, false);

            // 2 invalid parameters
            ComplexTest_FullValidation(invalidAmount, invalidEmail, validCountry, validFoo, validBar, false);
            ComplexTest_FullValidation(invalidAmount, validEmail, invalidCountry, validFoo, validBar, false);
            ComplexTest_FullValidation(invalidAmount, validEmail, validCountry, invalidFoo, validBar, false);
            ComplexTest_FullValidation(invalidAmount, validEmail, validCountry, validFoo, invalidBar, false);

            ComplexTest_FullValidation(validAmount, invalidEmail, invalidCountry, validFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, invalidEmail, validCountry, invalidFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, invalidEmail, validCountry, validFoo, invalidBar, false);

            ComplexTest_FullValidation(validAmount, validEmail, invalidCountry, invalidFoo, validBar, false);
            ComplexTest_FullValidation(validAmount, validEmail, invalidCountry, validFoo, invalidBar, false);

            ComplexTest_FullValidation(validAmount, validEmail, validCountry, invalidFoo, invalidBar, false);

            // 3 invalid parameters (2 valid parameters)
            ComplexTest_FullValidation(validAmount, validEmail, invalidCountry, invalidFoo, invalidBar, false);
            ComplexTest_FullValidation(validAmount, invalidEmail, validCountry, invalidFoo, invalidBar, false);
            ComplexTest_FullValidation(validAmount, invalidEmail, invalidCountry, validFoo, invalidBar, false);
            ComplexTest_FullValidation(validAmount, invalidEmail, invalidCountry, invalidFoo, validBar, false);

            ComplexTest_FullValidation(invalidAmount, validEmail, validCountry, invalidFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, validEmail, invalidCountry, validFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, validEmail, invalidCountry, invalidFoo, validBar, false);

            ComplexTest_FullValidation(invalidAmount, invalidEmail, validCountry, validFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, invalidEmail, validCountry, invalidFoo, validBar, false);

            ComplexTest_FullValidation(invalidAmount, invalidEmail, invalidCountry, validFoo, validBar, false);

            // 4 invalid parameters (1 valid parameters)
            ComplexTest_FullValidation(validAmount, invalidEmail, invalidCountry, invalidFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, validEmail, invalidCountry, invalidFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, invalidEmail, validCountry, invalidFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, invalidEmail, invalidCountry, validFoo, invalidBar, false);
            ComplexTest_FullValidation(invalidAmount, invalidEmail, invalidCountry, invalidFoo, validBar, false);

            // all invalid parameters
            ComplexTest_FullValidation(invalidAmount, invalidEmail, invalidCountry, invalidFoo, invalidBar, false);

            // all valid parameters
            ComplexTest_FullValidation(validAmount, validEmail, validCountry, validFoo, validBar, true);

            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine();
        }

        private void ComplexTest_BasicValidation(decimal amount,
                                                 string email,
                                                 string foo,
                                                 bool expected)
        {
            var chainValidationContext = new Complex.ChainValidators.ValidateContext()
            {
                Amount = amount,
                Email = email
            };

            var individualValidationContext = new Complex.IndividualValidators.ValidateContext()
            {
                Foo = foo
            };
            var actual = new Complex.ValidatorManager().BasicValidation(chainValidationContext, individualValidationContext);
            Assert(expected, actual);
        }

        private void ComplexTest_FullValidation(decimal amount,
                                                string email,
                                                string country,
                                                string foo,
                                                string bar,
                                                bool expected)
        {
            var chainValidationContext = new Complex.ChainValidators.ValidateContext()
            {
                Amount = amount,
                Email = email,
                Country = country
            };

            var individualValidationContext = new Complex.IndividualValidators.ValidateContext()
            {
                Foo = foo,
                Bar = bar
            };
            var actual = new Complex.ValidatorManager().FullValidation(chainValidationContext, individualValidationContext);
            Assert(expected, actual);
        }

        #endregion


        #region BackToBasicTest

        public void BackToBasicTest()
        {
            var manager = new BackToBasic.ValidatorManager();

            Console.WriteLine($"BackToBasic.ValidatorManager.BasicToBasicValidation() => ");
            BackToBasicTest_BasicToBasicValidation(invalidAmount, validEmail, validFoo, validBar, false);
            BackToBasicTest_BasicToBasicValidation(validAmount, invalidEmail, validFoo, validBar, false);
            BackToBasicTest_BasicToBasicValidation(invalidAmount, invalidEmail, validFoo, validBar, false);
            BackToBasicTest_BasicToBasicValidation(validAmount, validEmail, validFoo, validBar, true);

            BackToBasicTest_BasicToBasicValidation(validAmount, validEmail, invalidFoo, validBar, true);
            BackToBasicTest_BasicToBasicValidation(validAmount, validEmail, validFoo, invalidBar, true);
            BackToBasicTest_BasicToBasicValidation(validAmount, validEmail, validFoo, validBar, true);
            BackToBasicTest_BasicToBasicValidation(validAmount, validEmail, invalidFoo, invalidBar, false);


            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine();
        }

        private void BackToBasicTest_BasicToBasicValidation(decimal amount, string email, string foo, string bar, bool expected)
        {
            var actual = new BackToBasic.ValidatorManager().BasicToBasicValidation(amount, email, foo, bar);
            Assert(expected, actual);
        }

        #endregion

        private void Assert(bool expected, bool actual)
        {
            if (expected != actual)
            {
                throw new Exception("actual not match expected");
            }

            Console.WriteLine($"expected: {expected}, actual match expected");
        }
    }
}
