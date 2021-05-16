using System;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Console I/O");
            GetUserDate();

            // Отдельный заполнитель допускается повторять внутри заданной строки.
            Console.WriteLine("{0}, Number {0}, Number {0}", 9);
            // Можно помещать каждый заполнитель в любую позицию внутри строкового литерала.
            Console.WriteLine("{1} {0} {2}", 10, 20, 30);

            FormatNumericalData();

            DisplayMessage();

            Console.ReadLine();
        }

        private static void DisplayMessage()
        {
            // Использование string.Format() для форматирования строкового литереала.
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);

            // Для этого кода требуется ссылка на PresentationFramework.dll
            //System.Windows.MessageBox.Show(userMessage);
        }

        /// <summary>
        /// Демонстрация применения некоторых дескрипторов формата.
        /// </summary>
        private static void FormatNumericalData()
        {
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            // Использование для символа шестнадцаричного формата
            // верхнего или нижнего регистра определяет регистр отображаемых символов.
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
        }

        private static void GetUserDate()
        {
            // Получить информацию об имени и возрасте.
            Console.Write("Please enter your name: "); // Предложить ввести имя
            string userName = Console.ReadLine();
            Console.Write("Please enter your age: "); // Предложить ввести возраст
            string userAge = Console.ReadLine();

            // Просто ради забавы изменить цвет переднего плана.
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Вывести полученную информацию на консоль.
            Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);

            // Востановить предыдущий цвет переднего плана.
            Console.ForegroundColor = prevColor;
        }
    }
}
