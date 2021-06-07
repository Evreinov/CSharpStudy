using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inheritance *****\n");

            // Создать объект Car и установить максимальную скорость.
            Car myCar = new Car(80);
            // Установить текущую скорость и вывести её на консоль.
            myCar.Speed = 50;
            Console.WriteLine("My car is going {0} MPH", myCar.Speed);
            Console.ReadLine();

            // Создать объект MiniVan.
            MiniVan myVan = new MiniVan();
            // Ошибка! Доступ к закрытым членам невозможен!
            //myVan.currSpeed = 55;
            myVan.Speed = 10;
            Console.WriteLine("My van is going {0} MPH", myVan.Speed);
            Console.ReadLine();
        }
    }
}
