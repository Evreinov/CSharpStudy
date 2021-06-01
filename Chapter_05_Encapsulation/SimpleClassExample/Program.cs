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

            Console.WriteLine("***** Fun with Class Types Again *****\n");
            Console.ReadLine();
            // Создать объект Motorcycle.
            Motorcycle motorcycle = new Motorcycle(5);
            motorcycle.SetDriverName("Tiny");
            motorcycle.PopAWheely();
            Console.WriteLine("Rider name is {0}", motorcycle.driverName);
            Console.ReadLine();
            MakeSomeBikes();
            Console.ReadLine();
        }

        static void MakeSomeBikes()
        {
            //driverName = "", driverIntensity = 0
            Motorcycle m1 = new Motorcycle();
            Console.WriteLine("Name= {0}, Intensity= {1}", m1.driverName, m1.driverIntensity);
            //driverName = "Tiny", driverIntensity = 0
            Motorcycle m2 = new Motorcycle(name: "Tiny");
            Console.WriteLine("Name= {0}, Intensity= {1}", m2.driverName, m2.driverIntensity);
            //driverName = "", driverIntensity = 7
            Motorcycle m3 = new Motorcycle(7);
            Console.WriteLine("Name= {0}, Intensity= {1}", m3.driverName, m3.driverIntensity);
        }
    }
}
