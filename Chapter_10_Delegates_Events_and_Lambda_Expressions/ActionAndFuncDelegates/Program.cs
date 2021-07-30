using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****");

            // Использовать делегат Action<> для указания на DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            // Использовать делегат Func<> для указания на Add.
            //Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            // Синтаксис групповых преобразований методов.
            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);

            // Использовать делегат Func<> для указания на SumToString.
            //Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            // Синтаксис групповых преобразований методов.
            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2.Invoke(90, 300);
            Console.WriteLine(sum);


            Console.ReadLine();
        }

        // Это цель для делегата Action<>.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Установить цвет текста в консоли.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Восстановить цвет.
            Console.ForegroundColor = previous;
        }

        // Цель для делегата Func<>.
        static int Add(int x, int y)
        {
            return x + y;
        }

        // Вторая цель для делегата Func<>.
        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}
