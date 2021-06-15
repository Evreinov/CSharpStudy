using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Method Overloading *****\n");
            // Вызов int-версии Add().
            Console.WriteLine(Add(10, 10));

            // Вызов long-версии Add().
            Console.WriteLine(Add(900_000_000_000, 900_000_000_000));

            // Вызов double-версии Add().
            Console.WriteLine(Add(4.3, 4.4));
            Console.ReadLine();
        }

        // Перешруженный метод Add().
        static int Add(int x, int y) => x + y;
        static double Add(double x, double y) => x + y;
        static long Add(long x, long y) => x + y;
    }
}
