using System;
using System.Numerics;

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
            ParseFromString();
            ParseFromStringsWithTryParse();
            UseDatesAndTimes();
            UseBigInteger();
            DigitSeparators();
            BinaryLiterals();
        }

        private static void BinaryLiterals()
        {
            Console.WriteLine("=> Use Binary Literals:");
            Console.WriteLine("Sixteen: {0}", 0b0001_0000);
            Console.WriteLine("Thirty Two: {0}", 0b0010_0000);
            Console.WriteLine("Sixty Four: {0}", 0b0100_0000);
        }

        static void DigitSeparators()
        {
            Console.WriteLine("=> Use Digit Separators:");
            Console.WriteLine("Integer:");
            Console.WriteLine(123_456);
            Console.WriteLine("Long:");
            Console.WriteLine(123_456_789L);
            Console.WriteLine("Float:");
            Console.WriteLine(123_456.1234F);
            Console.WriteLine("Double:");
            Console.WriteLine(123_456.12);
            Console.WriteLine("Decimal:");
            Console.WriteLine(123_456.12M);
            Console.WriteLine();
        }

        static void UseBigInteger()
        {
            Console.WriteLine("=> Use BigInteger:");
            // Литерал лучше задавать в виде строки, чтобы исполняющая среда не трактовала число, как int.
            BigInteger biggy = BigInteger.Parse("999999999999999999999999999999999999999999999999999999999999999999999");
            Console.WriteLine("Value of biggy is {0}", biggy); // значение biggy
            Console.WriteLine("Is biggy an even value?: {0}", biggy.IsEven); // biggy - четное?
            Console.WriteLine("Is biggy a power of two?: {0}", biggy.IsPowerOfTwo); // biggy - степень 2?
            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("88888888888888888888888888888888888888888888888888888888888888888"));
            BigInteger reallyBig2 = biggy * reallyBig; // Можно вместо Multiply
            Console.WriteLine("Value of reallyBig is {0}", reallyBig); // Значение reallyBig
            Console.WriteLine();
        }

        static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Dates and Times:");
            // Этот конструктор принимает год, месяц и день.
            DateTime dt = new DateTime(2015, 10, 17);
            // Какой это день месяца?
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            // Сейчас месяц декабрь.
            dt = dt.AddMonths(2);
            Console.WriteLine("Daylight saving: {0}", dt.IsDaylightSavingTime());
            // Этот конструктор принимает часы, минуты и секунды.
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);
            // Вычесть 15 минут из текущего значения TimeSpan и вывести результат.
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));
            Console.WriteLine();
        }

        static void ParseFromStringsWithTryParse()
        {
            Console.WriteLine("=> Data type parsing with TryParse:");
            if (bool.TryParse("True", out bool b))
            {
                Console.WriteLine("Value of b: {0}", b); // Вывод значения b
            }
            string value = "Hello";
            if (double.TryParse("True", out double d))
            {
                Console.WriteLine("Value of b: {0}", d); // Вывод значения d
            }
            else
            {
                // Преобразование потерпело неулачу
                Console.WriteLine("Failed to convert the input ({0}) to a double", value);
            }
            Console.WriteLine();
        }

        static void ParseFromString()
        {
            Console.WriteLine("=> Data type parsing");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b {0}", b); // Вывод значения b
            double d = double.Parse("99,884");
            Console.WriteLine("Value of d {0}", d); // Вывод значения d
            int i = int.Parse("8");
            Console.WriteLine("Value of i {0}", i); // Вывод значения i
            char c = char.Parse("w");
            Console.WriteLine("Value of c {0}", c); // Вывод значения c
            Console.WriteLine();
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
