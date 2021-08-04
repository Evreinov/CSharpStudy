using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringWithOperators();
            Console.WriteLine();
            QueryStringWithEnumerableAndLambdas();
            Console.WriteLine();
            QueryStringWithEnumerableAndLambdas2();
            Console.WriteLine();
            QueryStringWithAnonymousMethods();
            Console.WriteLine();
            VeryComplexQueryExpression.QueryStringWithRawDelegates();
            Console.ReadLine();
        }

        /// <summary>
        /// Построение выражений запросов с применением операций запросов.
        /// </summary>
        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter", "System Shock 2" };
            var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game;
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        /// <summary>
        /// Построение выражений запросов с использованием типа Enumerable и лямбда-выражений.
        /// </summary>
        static void QueryStringWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter", "System Shock 2" };
            // Построить выражение запроса с использованием расширяющих методов,
            // предоставленных типу Array через тип Enumerable.
            var subset = currentVideoGames
                .Where(game => game.Contains(" "))
                .OrderBy(game => game)
                .Select(game => game);
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        /// <summary>
        /// Построение выражений запросов с использованием типа Enumerable и лямбда-выражений.
        /// </summary>
        static void QueryStringWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter", "System Shock 2" };
            // Построить выражение запроса с использованием расширяющих методов,
            // предоставленных типу Array через тип Enumerable.
            // Разбитый на части.
            var gameWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            var orderedGames = gameWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        /// <summary>
        /// Построение выражений запросов с использованием типа Enumerable и анонимных методов.
        /// </summary>
        static void QueryStringWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter", "System Shock 2" };
            
            // Построить необходимые делегаты Func<> с использованием анонимных методов.
            Func<string, bool> searchFilter = delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };

            // Передать делегаты в методы класса Enumerable.
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
    }

    /// <summary>
    /// Построение выражений запросов с использованием типа Enumerable и низкоуровневых делегатов.
    /// </summary>
    class VeryComplexQueryExpression
    {
        /// <summary>
        ///  Построение выражений запросов с использованием типа Enumerable и низкоуровневых делегатов.
        /// </summary>
        public static void QueryStringWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");
            string[] currentVideoGames =
                { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter", "System Shock 2" };

            // Построить необходимые делегаты Func<>.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            // Передать делегаты в методы класса Enumerable.
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        //Цели делегатов.
        public static bool Filter(string game)
        {
            return game.Contains(" ");
        }
        public static string ProcessItem(string game)
        {
            return game;
        }
    }
}
