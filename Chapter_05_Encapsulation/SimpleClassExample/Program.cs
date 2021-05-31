using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            MotorcycleOld mc = new MotorcycleOld();
            mc.PopAWheely();
            // Ошибка на этапе компиляции! Забыли использовать new для создания объекта.
            //Car myCarError;
            //myCarError.petName = "Fred";

            // Создать объект Car по имени Chuck со скоростью 10 миль в час.
            Car chuck = new Car();
            chuck.PrintState();
            // Создать объект Car по имени Mary со скоростью 0 миль в час.
            Car mary = new Car("Mary");
            mary.PrintState();
            // Создать объект Car по имени Daisy со скоростью 75 миль в час.
            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();

            // Разместить в памяти и сконфигурировать объект Car...
            Car myCar = new Car();
            // ...или
            //Car myCar;
            //myCar = new Car();
            //myCar.petName = "Fred";

            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            // Увеличить скорость автомобиля в несколько раз и вывести новое состояние.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
            Console.ReadLine();

            // Создать объект Motorcycle с мотоциклистом по имени Tiny.
            MotorcycleOld c = new MotorcycleOld(5);
            c.SetDriverName("Tiny");
            c.PopAWheely();
            Console.WriteLine("Rider name is {0}", c.name);
            Console.ReadLine();
        }
    }
}
