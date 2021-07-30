using System;

namespace CarEventsWithLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** More Fun with Lambdas *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }
    }
}
