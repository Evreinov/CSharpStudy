using System;
using System.Text;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicStringFunctionality();
            StringConcatenation();
            EscapeChars();
            StringEquality();
            StringEqualitySpecifyingCompareRules();
            StringsAreImmutable();
            StringsAreImmutable2();
            FunWithStringBuilder();
            Console.Read();
        }

        /// <summary>
        /// Базовые манипуляции строками.
        /// </summary>
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

        /// <summary>
        /// Конкатенация строк
        /// </summary>
        static void StringConcatenation()
        {
            Console.WriteLine("=> String concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2; // Запускает String.Concat()
            //string s3 = String.Concat(s1, s2);
            Console.WriteLine(s3);
            Console.WriteLine();
        }

        /// <summary>
        /// Управляющие последовательности
        /// </summary>
        static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Everyone loves \"Hello World\"\a");
            Console.WriteLine("C:\\NyApp\\bin\\Debug\a");

            // Добавить четыре пустых строки и снова вызвать звуковой сигнал
            Console.WriteLine("All finished.\n\n\n\a");
            Console.WriteLine();

            // Дословные строки
            // Следующая строка воспроизводится дословно,
            // так что отображаются все управляющие символы.
            Console.WriteLine(@"C:\MyApp\bin\Debug");
            // При использовании дословных строк пробельные символы предохраняются.
            string myLongString = @"This is a very
                very
                    very
                        long string";
            Console.WriteLine(myLongString);
            // Двойные кавычки в дословной строке, просто дублируется знак "
            Console.WriteLine(@"Cerebus said ""Darrrr! Pret-ty sun-sets""");
            Console.WriteLine();
        }

        /// <summary>
        /// Строки и равенство
        /// </summary>
        static void StringEquality()
        {
            // String является ссылочных типом данных, но операции равенства переопределены так,
            // чтобы сравнивать значения объектов, а не определять указывают ли ссылки на один и тот же объект.
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Проверить строки на равенство
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();
        }

        /// <summary>
        /// Модификация поведения сравнения строк
        /// </summary>
        static void StringEqualitySpecifyingCompareRules()
        {
            Console.WriteLine("=> String equality (Case Insensitive):");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            // Проверить результаты изменения стандарных правил сравнения.
            Console.WriteLine("Default rules: s1={0}, s2={1}s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));
            Console.WriteLine("Ignore case:  s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}",
                s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}",
                s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Default rules: s1={0}, s2={1}s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));
            Console.WriteLine("Ignore case:  s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
        }

        /// <summary>
        /// Строки являются неизменными
        /// </summary>
        static void StringsAreImmutable()
        {
            // Установить начальное значение для строки
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);

            // Преобразована ли строка s1 в верхний регистр
            string upperString = s1.ToUpper();
            Console.WriteLine("upperSting = {0}", upperString);

            // Нет! Строка s1 осталась в том же виде!
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine();
        }

        /// <summary>
        /// Строки являются неизменными
        /// </summary>
        static void StringsAreImmutable2()
        {
            string s2 = "My other string";
            s2 = "New string value";
        }

        /// <summary>
        /// Тип System.Text.StringBuilder
        /// </summary>
        static void FunWithStringBuilder()
        {
            // Создать экземпляр StringBuilder с исходным размером в 256 символов.
            // StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }


        /// <summary>
        /// Интерполяция строк
        /// </summary>
        static void StringInterpolation()
        {
            // Некоторые локальные переменные будут включены в крупную строку.
            int age = 4;
            string name = "Soren";

            // Использование синтаксиса с фигурными скобками.
            string greeting = string.Format("\tHello {0} you are {1} years old.", name.ToUpper(), age);

            // Использование интерполяции строк.
            string greeting2 = $"\tHello {name.ToUpper()} you are {age} years old.";
        }
    }
}
