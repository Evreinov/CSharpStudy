using System;

namespace BasicDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalVarDeclarations();
            DefaultDeclarations();
            NewingDataTypes();
            ObjectFunctionality();
            DataTypeFunctionality();
            BooleanFunctionality();
            CharFunctionality();
        }

        static void ObjectFunctionality()
        {
            Console.WriteLine("=> System.Object Functionality:");
            // Ключевое слово int языка C# - это в действительности сокращение для 
            // типа System.Int32, который наследует от System.Object следующие члены:
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine();
        }

        static void DataTypeFunctionality()
        {
            Console.WriteLine("=> Data type Functionality");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);
            Console.WriteLine();
        }

        static void BooleanFunctionality()
        {
            Console.WriteLine("=> Boolean type Functionality");
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            Console.WriteLine();
        }

        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}", char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There, 6'): {0}", char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine();
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("=> Using new to create variables:");
            bool b = new bool(); // Устанавливается в false;
            int i = new int(); // Устанавливается в 0.
            double d = new double(); // Устанавливается в 0.
            DateTime dt = new DateTime(); // // Устанавливается в 1/1/0001 12:00:00 AM
            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
        }

        private static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations:");
            int myInt = default;
        }

        private static void LocalVarDeclarations()
        {
            Console.WriteLine("=> Data Declarations:");
            // Локальные переменные объявляются так:
            // типДанных имяПеременной;

            // Локальные переменные объявляются и инициализируются так:
            // типДанных имяПеременной = начальноеЗначение;
            int myInt = 0;
            // Объявлять и присваивать можно также в двух отдельных строках.
            string myString;
            myString = "This is my character data";
            // Объявить три перменных типа bool в одной строке.
            bool b1 = true, b2 = false, b3 = b1;
            // Использовать тип данных System.Boolean для объявления булевской переменной.
            System.Boolean b4 = false;

            Console.WriteLine("Your data: {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);
            Console.WriteLine();
        }
    }
}
