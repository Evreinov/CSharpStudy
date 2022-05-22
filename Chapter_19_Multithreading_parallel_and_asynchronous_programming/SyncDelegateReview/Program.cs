using System;
using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            // Вывести идентификатор выполняющего потока.
            Console.WriteLine("Main() invoke on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() в синхронном режиме.
            var b = new BinaryOp(Add);
            
            // Можно было бы также написать b.Invoke(10, 10);
            var answer = b(10, 10);

            // Эти строки кода не выполнятся до тех пор,
            // пока не завершится метод Add().
            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Вывести идентификатор выполняющего потока.
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
