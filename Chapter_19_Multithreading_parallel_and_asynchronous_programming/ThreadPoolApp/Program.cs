using System;
using System.Threading;

namespace ThreadPoolApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");

            Console.WriteLine("Main thread started. ThreadID={0}", Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();

            WaitCallback workItem = new WaitCallback(PrinterTheNumbers);

            // Поставить в очередь метод 10 раз.
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }

            Console.WriteLine("All task queued");

            Console.ReadLine();
        }

        private static void PrinterTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
