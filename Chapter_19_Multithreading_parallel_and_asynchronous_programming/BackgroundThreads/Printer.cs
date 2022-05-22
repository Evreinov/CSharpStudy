using System;
using System.Threading;

namespace BackgroundThreads
{
    public class Printer
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            
            // Вывести числа.
            Console.WriteLine("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}, ", i);
                Thread.Sleep(2000);
            }

            Console.WriteLine();
        }
    }
}
