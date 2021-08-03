using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            Console.WriteLine();
            QueryOverStringsWithExtensionMethods();
            Console.WriteLine();
            QueryOverStringsLongHand();
            Console.WriteLine();
            QueryOverInts();
            Console.ReadLine();

        }

        /// <summary>
        /// Применение запросов LINQ к элементарным массивам.
        /// </summary>
        static void QueryOverStrings()
        {
            // Предположим, что есть массив строк.
            string[] currentVideoGames = 
                { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Построить выражение запроса для нахождения
            // элементов массива, которые содержат пробелы.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;
            
            ReflectOverQueryResults(subset);

            // Вывести результаты.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        /// <summary>
        /// Решение с использованием расширяющих методов.
        /// </summary>
        static void QueryOverStringsWithExtensionMethods()
        {
            // Пусть имеется массив строк.
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Построить выражение запроса для поиска
            // в массиве элементов, содержащие пробелы.
            IEnumerable<string> subset =
                currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

            ReflectOverQueryResults(subset, "Extension Methods");

            // Вывести результаты.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        /// <summary>
        /// Решение без использования LINQ.
        /// </summary>
        static void QueryOverStringsLongHand()
        {
            // Предположим, что есть массив строк.
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            string[] gamesWithSpaces = new string[5];

            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }

            // Отсортировать набор.
            Array.Sort(gamesWithSpaces);

            // Вывести результаты.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выполнение рефлексии результирующего набора LINQ.
        /// </summary>
        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            // Вывести тип результирующего набора.
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            // Вывести местоположение результирующего набора.
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        /// <summary>
        /// LINQ и неявно типизированные локальные переменные.
        /// </summary>
        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Вывести только элементы меньше 10.
            //System.Collections.IEnumerable subset = from i in numbers where i < 10 select i;
            // В качестве эмпирического правила: при захвате результатов запроса LINQ всегда
            // необходимо использовать неявную типизацию. Однако (в подавляющем большинстве случаев)
            // действительное возвращаемое значение имеет тип, реализующий интерфейс IEnumerable<T>.
            var subset = from i in numbers where i < 10 select i;
            
            foreach (var i in subset)
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subset);
        }
    }
}
