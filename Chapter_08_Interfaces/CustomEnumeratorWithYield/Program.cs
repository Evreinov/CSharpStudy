using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();

            // Проход по всем объетам Car в коллекции ?
            //foreach (Car c in carLot)
            //{
            //    Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            //}

            //IEnumerator carEnumerator = carLot.GetEnumerator();
            Console.WriteLine();

            // Получить элементы (в обратном порядке!)
            // с применением именованного итератора.
            foreach (Car c in carLot.GetTheCars(true))
            {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }
            Console.ReadLine();
        }
    }
}
