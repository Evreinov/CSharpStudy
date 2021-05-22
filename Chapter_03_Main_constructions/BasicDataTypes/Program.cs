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
