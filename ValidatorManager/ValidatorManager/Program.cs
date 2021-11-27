using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorManager
{
    class Program
    {
        private static decimal validAmount = 11;
        private static string validEmail = "ron.sun@mailserver.com";
        private static string validCountry = "Taiwan";
        private static string validFoo = "Foo";
        private static string validBar = "Bar";

        static void Main(string[] args)
        {
            // Test
            var tests = new Tests();
            tests.BasicTest();
            tests.SimpleTest();
            tests.AdvanceTest();
            tests.ComplexTest();
            tests.BackToBasicTest();

            Console.ReadLine();
        }
    }
}
