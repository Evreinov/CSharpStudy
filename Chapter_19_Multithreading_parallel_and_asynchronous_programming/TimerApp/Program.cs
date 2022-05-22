using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApp
{
    internal class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}, Param is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            // Создать делегат для типа Timer.
            TimerCallback timeCB = new TimerCallback(PrintTime);

            // Установить параметры таймера.
            // _ - автономное отбрасование.
            Timer _ = new Timer(
                timeCB, // Объект делегата TimerCallback.
                "Hello From Main", // Информация для передачи в вызванный метод (null, если информация отсутствует).
                0, // Период ожидания перед запуском (в миллисекундах).
                1000 // Интервал между вызовами (в миллисекундах).
                );

            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();
        }
    }
}
