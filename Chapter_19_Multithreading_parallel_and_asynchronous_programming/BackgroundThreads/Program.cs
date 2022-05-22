using System;
using System.Threading;

namespace BackgroundThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Background Threads *****\n");
            Printer p = new Printer();
            Thread bgroundThread = new Thread(p.PrintNumbers);

            // Теперь это фоновый поток.
            bgroundThread.IsBackground = true;
            bgroundThread.Start();
        }
    }
}
