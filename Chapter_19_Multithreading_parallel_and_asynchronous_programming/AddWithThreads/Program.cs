using System;
using System.Threading;

namespace AddWithThreads
{
    internal class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false); // false указывает, что уведомления пока не было.
        // Передача параметров во вторичный поток с помощью делегата ParametrizedThreadStart.
        static void Main(string[] args)
        {
            #region Вариант 1 

            //Console.WriteLine("***** Adding with Thread objects *****");
            //Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);

            //// Создать объект AddParams для передачи вторичному потоку.
            //AddParams ap = new AddParams(10, 10);
            //Thread t = new Thread(new ParameterizedThreadStart(Add));
            //t.Start(ap);
            //// Подождать пока другой поток завершится.
            //Thread.Sleep(5);
            //Console.ReadLine();

            #endregion

            #region Вариант 2 - с использованием класса AutoResetEvent

            //<remarks>
            //В предыдущем примере информирования первичного потока используется ряд грубых способов.
            //1. Использовалась общая булевская переменная (примеры с делегатами).
            //2. Thread.Sleep() c фиксированым периодом времени ожидания.
            //<remarks>
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);

            // Создать объект AddParams для передачи вторичному потоку.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            // Ожидать, пока не поступит уведомление!
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();

            #endregion
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);

                // Сообщить другому потоку о том, что работа завершена.
                waitHandle.Set();
            }
        }
    }
}
