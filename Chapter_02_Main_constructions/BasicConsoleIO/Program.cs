using System;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Console I/O");
            GetUserDate();
            Console.ReadLine();
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
