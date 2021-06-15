using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Automatic Properties *****\n");

            Car c = new Car();
            c.PetName = "Frank";
            c.Speed = 55;
            c.Color = "Red";
            Console.WriteLine("You car is named {0}? That's odd...", c.PetName);
            c.DisplayStats();

            // Поместить автомобиль в гараж
            Garage g = new Garage();
            g.MyAuto = c;
            // Вывести колличесвто автомобилей в гараже.
            Console.WriteLine("Number of Cars: {0}", g.NumberOfCars);
            // Вывести название автомобиля.
            Console.WriteLine(g.MyAuto.PetName);
            Console.ReadLine();
        }
    }
}
