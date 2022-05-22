using System;
using System.Threading;

namespace AsyncDelegate
{
    internal class Program
    {
        public delegate int BinaryOp(int x, int y);

        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() во вторичном потоке.
            //<remark>
            // После обработки следующего оператора вызывающий поток блокируется,
            // пока не будет завершен BeginInvoke().
            //</remark>
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);

            #region Вариант 1.
            // Выполнить другую работу в первичном потоке.
            //<remark>
            // Этот вызов занимает намного меньше пяти секунд!
            //<remark>
            //Console.WriteLine("Doing more work in Main()!");

            // По готовности получить результат выполнения метода Add().
            //<remark>
            // Снова происходит ожидание завершения другого потока.
            //<remark>
            //int answer = b.EndInvoke(ar);
            #endregion

            #region Вариант 2.
            // У делегатов есть совйство IsCompleted, которое если метод не завершился 
            // возвращает false, и вызывающий поток может заниматься своей работой. Когда
            // IsCompleted возвращает true, вызывающий поток может получить результат в " наименее 
            // блокирующей манере.

            // Это сообщение продолжится выводится до тех пор,
            // пока не будет завершен метод Add(().
            //while (!ar.IsCompleted)
            //{
            //    Console.WriteLine("Doing more work in Main()!");
            //    Thread.Sleep(1000);
            //}

            // Теперь известно, что метод Add() завершен.
            //int answer = b.EndInvoke(ar);
            #endregion

            #region Вариант 3.
            // Аналогичен второму варианту, только в нем указывается максимальное время ожидания.

            while (!ar.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Doing more work in Main()!");
            }

            // Теперь известно, что метод Add() завершен.
            int answer = b.EndInvoke(ar);
            #endregion

            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Вывести идентификатор выпоняющегося потока.
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);

            return  x + y;
        }
    }
}
