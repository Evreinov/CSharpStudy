using System;
using System.Threading;

namespace ThreadPoolApp
{
    public class Printer
    {
        private readonly object threadLock = new object();
        public void PrintNumbers()
        {
            // Использовать в качестве маркера блокировки закрытый член object.
            lock (threadLock)
            {
                // Вывести информацию о потоке.
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                // Вывести числа.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    // Приостановить поток на случайный период времени.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }
    }
}
