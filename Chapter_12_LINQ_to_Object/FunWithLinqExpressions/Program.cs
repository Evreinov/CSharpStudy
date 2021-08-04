using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");

            // Этот массив будет основой для тестирования...
            ProductInfo[] itemsInStock = new[] {
                new ProductInfo { Name = "Mac's Coffee", 
                    Description = "Coffee with TEETH", 
                    NumberInStock = 24 },
                new ProductInfo { Name = "Milk Maid Milk",
                    Description = "Milk cow's love",
                    NumberInStock = 100 },
                new ProductInfo { Name = "Pure Silk Tofu",
                    Description = "Bland as Possible",
                    NumberInStock = 120 },
                new ProductInfo { Name = "Crunchy Pops",
                    Description = "Cheezy, peppery goodness",
                    NumberInStock = 2 },
                new ProductInfo { Name = "RipOff Water",
                    Description = "From the tap to your wallet",
                    NumberInStock = 100 },
                new ProductInfo { Name = "Classic Valpo Pizza",
                    Description = "Everyone loves pizza!",
                    NumberInStock = 73 },
            };
            // Вызов разнообразных методов.
            SelectEveryThing(itemsInStock);
            Console.WriteLine();

            ListProductNames(itemsInStock);
            Console.WriteLine();

            GetOverstock(itemsInStock);
            Console.WriteLine();

            GetNamesAndDescriptions(itemsInStock);
            Console.WriteLine();

            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o); // Вызывает метод ToString() на каждом анонимном объекте.
            }
            Console.WriteLine();

            GetCountFromQuery();
            Console.WriteLine();

            ReverseEverything(itemsInStock);
            Console.WriteLine();

            AlphabetizeProductNames(itemsInStock);
            Console.WriteLine();

            DisplayDiff();
            DisplayIntersection();
            DisplayUnion();
            DisplayConcat();
            Console.WriteLine();

            DisplayConcatNoDups();
            Console.WriteLine();

            AggregateOps();
            Console.ReadLine();
        }

        #region Базовый синтаксис выборки.
        // var результат = from сопоставляемыйЭлемент in контейнер select сопоставляемыйЭлемент;
        
        /// <summary>
        /// Базовый синтаксис выборки.
        /// </summary>
        static void SelectEveryThing(ProductInfo[] products)
        {
            // Получить всё!
            Console.WriteLine("All product details:");
            var allProduct = from p in products select p;
            foreach (var prod in allProduct)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        /// <summary>
        /// Базовый синтаксис выборки (только значения Name).
        /// </summary>
        static void ListProductNames(ProductInfo[] products)
        {
            // Теперь получить только наименования товаров.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;
            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n);
            }
        }
        #endregion

        #region Получение подмножества данных.
        // var результат = from элемент in контейнер where булевскоеВыражение select элемент;

        /// <summary>
        /// Получение подмножества данных.
        /// </summary>
        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");
            // Получить только товары со складским запасом больше 25 единиц.
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c.ToString());
            }
        }
        #endregion

        #region Проецирование новых типов данных.

        /// <summary>
        /// Проецирование новых типов данных. 
        /// Для этого понадобится определить опереатор select, 
        /// динамически выдающий новый анонимный тип.
        /// </summary>
        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
            {
                // Можно было бы также использовать свойства Name и Description напрямую.
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Возвращаемое значение является объект Array.
        /// </summary>
        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            return nameDesc.ToArray();
        }
        #endregion

        #region Подсчет количества с использованием класса Enumerable.

        /// <summary>
        /// Подсчет количества с использованием класса Enumerable.
        /// </summary>
        static void GetCountFromQuery()
        {
            string[] currentVideoGames = 
                { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Получить количесвто элементов из запроса.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();

            // Вывести количество элементов.
            Console.WriteLine("{0} items honor the LINQ query", numb);
        }
        #endregion

        #region Изменение порядка следования элементов в результирующих наборах на противоположный.

        /// <summary>
        /// Изменение порядка следования элементов в результирующих наборах на противоположный.
        /// </summary>
        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Product in reverse:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts.Reverse())
            {
                Console.WriteLine(prod.ToString());
            }
        }
        #endregion

        #region Выражения сортировки.

        /// <summary>
        /// Выражения сортировки.
        /// </summary>
        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Получить названия товаров в алфавитном порядке.
            //var subset = from p in products orderby p.Name select p;
            //var subset = from p in products orderby p.Name ascending select p;
            // Получить названия товаров в порядке убывания.
            var subset = from p in products orderby p.Name descending select p;
            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
        }
        #endregion

        #region LINQ как лучшее средство построения диаграмм Венна.

        /// <summary>
        /// Except() - возвращает разность между контейнерами.
        /// </summary>
        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Выводит Yugo.
        }

        /// <summary>
        /// Intersect() - возвращает результирующий набор, 
        /// который содержит общие элементы данных в наборе контейнеров.
        /// </summary>
        static void DisplayIntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you have in common:");
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Выводит Aztec и BMW.
        }

        /// <summary>
        /// Union() - возвращает результирующий набор, 
        /// который включает все члены множества запросов LINQ. 
        /// Подобно любому объединению, даже если общий член встречается более одного раза, 
        /// повторяющихся значений в результирующем наборе не будет.
        /// </summary>
        static void DisplayUnion()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);

            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Выводит все общие члены.
        }

        /// <summary>
        /// Concat() - возвращает результирующий набор, 
        /// который является прямой конкатенацией наборов, объединяет все члены.
        /// </summary>
        static void DisplayConcat()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            Console.WriteLine("Here is everything:");
            foreach (string s in carConcat)
                Console.WriteLine(s); // Выводит все члены двух множеств..
        }
        #endregion

        #region Удаление дубликатов.

        /// <summary>
        /// Удаление дубликатов.
        /// </summary>
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s); // Выводит Yugo.
        }
        #endregion

        #region Операция агрегирования LINQ.

        /// <summary>
        /// Операция агрегирования LINQ.
        /// </summary>
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            // Разнообразные примеры агрегации. Выводит максимальную температуру.
            Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());
            // Выводит максимальную температуру.
            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
            // Выводит среднюю температуру.
            Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
            // Выводит сумму всех температур.
            Console.WriteLine("Sum of all temp: {0}", (from t in winterTemps select t).Sum());
        }
        #endregion
    }
}
