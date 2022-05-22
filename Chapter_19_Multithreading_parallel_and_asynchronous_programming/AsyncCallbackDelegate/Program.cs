using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);
    internal class Program
    {
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            //IAsyncResult ar = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);
            // IAsyncResult с передачей специальных данных состояния.
            IAsyncResult ar = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.");


            // Предположим, что здесь делается какая-то другая работа...
            while (!isDone)
            {
                Console.WriteLine("Working....");
                Thread.Sleep(1000);
            }

            //int answer = b.EndInvoke(ar);
            //Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        // Используется для получения уведомления о том, что асинхронный вызов завершен.
        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            // Получаем ссылку на объет делегата BinaryOp. Более элегантное решение.
            AsyncResult ar = (AsyncResult) iar;
            BinaryOp b = (BinaryOp) ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(iar));

            // Получить информационный объект (специальные данные состояния) и привести его к типу string.
            string msg = (string) iar.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }
    }
}
