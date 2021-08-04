using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Return Values *****\n");
            IEnumerable<string> subset = GetStingSubset();
            foreach (string item in subset)
            {
                Console.WriteLine(item);
            }

            foreach (string item in GetStingSubsetAsArray())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Возвращение результатов запроса LINQ.
        /// </summary>
        private static IEnumerable<string> GetStingSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            // Обратите внимание, что subset является
            // совместимым с IEnumerable<string> объектом.

            IEnumerable<string> theRedColors = from c in colors
                                               where c.Contains("Red")
                                               select c;

            return theRedColors;
        }

        /// <summary>
        /// Возвращение результатов LINQ посредством немедленного выполнения.
        /// </summary>
        static string[] GetStingSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            // Обратите внимание, что subset является
            // совместимым с IEnumerable<string> объектом.

            IEnumerable<string> theRedColors = from c in colors
                                               where c.Contains("Red")
                                               select c;

            return theRedColors.ToArray();
        }
    }
}
