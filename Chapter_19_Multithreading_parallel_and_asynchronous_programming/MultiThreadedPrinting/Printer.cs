using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace MultiThreadedPrinting
{
    //public class Printer
    //{
    #region Вариант 1 - без блокировки разделяемых ресурсов.

    //public void PrintNumbers()
    //{
    //    // Вывести информацию о потоке.
    //    Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

    //    // Вывести числа.
    //    Console.WriteLine("Your numbers: ");
    //    for (int i = 0; i < 10; i++)
    //    {
    //        // Приостановить поток на случайный период времени.
    //        Random r = new Random();
    //        Thread.Sleep(1000 * r.Next(5));
    //        Console.Write("{0}, ", i);
    //    }

    //    Console.WriteLine();
    //}

    #endregion

    #region Вариант 2 - Синхронизация с использованием ключевого слова lock языка C#.

    //private object threadLock = new object();

    // Синхронизация с использованием ключевого слова lock языка c#.
    //public void PrintNumbers()
    //{
    //    // Использовать в качестве маркера блокировки закрытый член object.
    //    lock (threadLock)
    //    {
    //        // Вывести информацию о потоке.
    //        Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

    //        // Вывести числа.
    //        Console.WriteLine("Your numbers: ");
    //        for (int i = 0; i < 10; i++)
    //        {
    //            // Приостановить поток на случайный период времени.
    //            Random r = new Random();
    //            Thread.Sleep(1000 * r.Next(5));
    //            Console.Write("{0}, ", i);
    //        }
    //        Console.WriteLine();
    //    }
    //}

    #endregion

    #region Вариант 3 - Синхронизация с использованием типа System.Threading.Monitor.

    //private object threadLock = new object();
    // Оператор lock языка C# на самом деле представляет собой сокращение для работы с классом System.Threading.Monitor.
    //public void PrintNumbers()
    //{
    //    Monitor.Enter(threadLock);
    //    try
    //    {
    //        // Вывести информацию о потоке.
    //        Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

    //        // Вывести числа.
    //        Console.WriteLine("Your numbers: ");
    //        for (int i = 0; i < 10; i++)
    //        {
    //            // Приостановить поток на случайный период времени.
    //            Random r = new Random();
    //            Thread.Sleep(1000 * r.Next(5));
    //            Console.Write("{0}, ", i);
    //        }
    //        Console.WriteLine();
    //    }
    //    finally
    //    {
    //        Monitor.Exit(threadLock);
    //    }
    //}

    #endregion

    #region Синхронизация с использованием типа System.Threading.Interlocked

    //private object myLockToken = new object();
    //private int intVal = default;
    //public void AddOne()
    //{   
    //    // Вместо данного варинта
    //    lock (myLockToken)
    //    {
    //        intVal++;
    //    }
    //    // лучше использовать.
    //    int newVal = Interlocked.Increment(ref intVal);
    //}

    //public void SafeAssignment()
    //{
    //    Interlocked.Exchange(ref intVal, 83);
    //}

    //public void CompareAndExchange()
    //{
    //    // Если значение intVal равно 83, то изменить его на 99.
    //    Interlocked.CompareExchange(ref intVal, 99, 83);
    //}

    #endregion
    //}

    #region Вариант 4 - Синхронизация с использованием атрибута [Synchronization]

    // Когда среда CLR размещает в памяти объекты, снабженные атрибутами [Synchronization]
    // она помещает объект внутрь контекста синхронизации.
    // Объекты которые не должны выходить за границы контекста, являются производными от ContextBoundObject.
    [Synchronization]
    public class Printer : ContextBoundObject
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            // Вывести числа.
            Console.WriteLine("Your numbers: ");
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

    #endregion
}
