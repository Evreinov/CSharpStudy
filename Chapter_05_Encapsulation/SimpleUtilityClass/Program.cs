using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtilityClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Classes *****\n");

            // Это работает нормально.
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            // Ошибка на этапе компиляции! Создать экземпляр статического
            // класса невозможно!
            //TimeUtilClass u = new TimeUtilClass();
            Console.ReadLine();
        }
    }
}
