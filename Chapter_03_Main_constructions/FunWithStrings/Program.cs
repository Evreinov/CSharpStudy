using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicStringFunctionality();
            Console.Read();
        }

        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName); // Значение firstName
            Console.WriteLine("firstName has {0} characters.", firstName.Length); // Длина firstName
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper()); // firstName в верхнем регистре
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower()); // firstName в нижнем регистре
            Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y")); // Содержит ли firstName букву y?
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy", "")); // firstName после замены.
            Console.WriteLine();
        }
    }
}
