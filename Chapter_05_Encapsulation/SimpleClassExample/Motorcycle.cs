using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    // Построение цепочки вызова конструкторов с использованием this.
    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        public Motorcycle() 
        {
            Console.WriteLine("In default ctor"); // Внутри стандартного конструктора.
        }

        //// Избыточная логика конструктора!
        //// Проверка, значения intensity, встречается в каждом конструкторе, что приводит
        //// к редактированию одного и того же кода в нескольких местах (избыточность).
        //public Motorcycle(int intensity)
        //{
        //    if (intensity > 10)
        //    {
        //        intensity = 10;
        //    }
        //    driverIntensity = intensity;
        //}

        //public Motorcycle(int intensity, string name)
        //{
        //    if (intensity > 10)
        //    {
        //        intensity = 10;
        //    }
        //    driverIntensity = intensity;
        //    driverName = name;
        //}

        // ==========================================================================================

        // Другая избыточность, постоянно необходимо в каждом конструкторе
        // вызывать метод SetIntensity(int intensity)
        //public Motorcycle(int intensity)
        //{
        //    SetIntensity(intensity);
        //}

        //public Motorcycle(int intensity, string name)
        //{
        //    SetIntensity(intensity);
        //    driverName = name;
        //}

        //public void SetIntensity(int intensity)
        //{
        //    if (intensity > 10)
        //    {
        //        intensity = 10;
        //    }
        //    driverIntensity = intensity;
        //}

        // ==========================================================================================

        // Более совершенный подход связанный с построением цепочки вызовов конструкторов с использованием this
        // Связывание конструкторов в цепочку.
        //public Motorcycle(int intensity) : this (intensity, "") 
        //{
        //    Console.WriteLine("In ctor taking an int"); // Внутри конструктора, принимающего int.
        //}

        //public Motorcycle(string name) : this(0, name)
        //{
        //    Console.WriteLine("In ctor taking an string"); // Внутри конструктора, принимающего string.
        //}

        //// Это главный конструктор, выполняющий всю реальную работу.
        //public Motorcycle(int intensity, string name)
        //{
        //    Console.WriteLine("In master ctor"); // Внутри главного конструктораю.
        //    if (intensity > 10)
        //    {
        //        intensity = 10;
        //    }
        //    driverIntensity = intensity;
        //    driverName = name;
        //}

        // ==========================================================================================

        // Конструктор начиная с версии 4.0 с помощью необязательных аргументов.
        // Единственный контсруктор, использующий необязательные аргументы.
        public Motorcycle(int intensity = 0, string name = "")
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }


        public void SetDriverName(string name)
        {
            driverName = name;
        }

        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeeee Haaaaaeewww!");
            }
        }
    }
}
