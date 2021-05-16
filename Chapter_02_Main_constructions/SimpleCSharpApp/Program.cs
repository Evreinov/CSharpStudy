using System;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    // Вывести пользователю простое сообщение.
        //    Console.WriteLine("***** My First C# App *****");
        //    Console.WriteLine("Hello World!");
        //    Console.WriteLine();

        //    // Ожидать нажатия клавиши <Enter>, прежде чем завершить работу.
        //    Console.ReadLine();
        //}

        static int Main(string[] args)
        {
            // Вывести сообщение и ожидать нажатия клавиши <Enter>.
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            // Обработать любые водные аргументы
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0}", args[i]);
            // Или
            foreach (string arg in args)
                Console.WriteLine("Arg: {0}", arg);

            // Доступ к аргументам командной строки с помощью GetCommandLineArgs(),
            // метод Main не нужно определять, как принимающий массив string.

            // Получить аргументы с использованием System.Environment.
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine("Arg: {0}", arg);

            Console.ReadLine();
            // Возвратить произвольный код ошибки.
            return -1;
        }

        /* Вариации метода main
        // Возвращаемый тип int, массив строк в качестве параметра.
        static int Main(string[] args)
        {
            // Перед выходом должен возвращать значение.
            return 0;
        }
        // Нет возвращаемого типа, нет параметров.
        static void Main()
        {
        }
        // Возвращаемый тип int, нет параметров.
        static int Main()
        {
            // Перед выходом должен возвращать значение.
            return 0;
        }

        // Асинхронные
        static Task Main() { }
        static Task<int> Main() { }
        static Task Main() { string[] }
        static Task<int> Main() { string[] }
        */
    }
}
