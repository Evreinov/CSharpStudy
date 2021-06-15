using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class DatabaseReader
    {
        // Поле данных типа, допускающие null.
        public int? numericValue = null;
        public bool? boolValue = true;

        // Обратите внимание на возвращаемый тип, допускающий null.
        public int? GetIntFromDatabase()
        {
            return numericValue;
        }

        // Обратите внимание на возвращаемый тип, допускающий null.
        public bool? GetBoolFromDatabase()
        {
            return boolValue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ошибка на этапе компиляции!
            // Типы значений не могут быть установлены в null!
            //bool myBool = null;
            //int myInt = null;

            // Все в порядке! Строки являются ссылочными числами.
            string myString = null;

            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader dr = new DatabaseReader();

            // Получить значение int из "базы данных".
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
                Console.WriteLine("Value of 'i' is: {0}", i.Value); // Вывод значения переменной i
            else
                Console.WriteLine("Value if 'i' is undefined."); // Значение переменной i не определено.

            // Получить значение bool из "базы данных".
            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
                Console.WriteLine("Value of 'b' is: {0}", b.Value); // Вывод значения переменной b
            else
                Console.WriteLine("Value if 'b' is undefined."); // Значение переменной b не определено.
            Console.ReadLine();

            // Если значение возвращаемого из GetIntFromDatabase(), равно 
            // null, то присвоить локальной переменной 100.
            // ?? - называется "операция объединения с null"
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);
            // аналогичный код без ??
            int? moreData = dr.GetIntFromDatabase();
            if (!moreData.HasValue)
                moreData = 100;
            Console.WriteLine("Value of moreData: {0}", moreData);
            Console.ReadLine();

            TesterMethod(null);
            Console.ReadLine();
        }

        static void LocalNullableVariables()
        {
            // Определить несколько локальных переменных, допускающих null.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];

            // Ошибка! Строки являются ссылочными типами!
            //string? s = "oops";
        }

        // Суффикс ? является просто сокращением для использования Nullable<T>
        static void LocalNullableVariablesUsingNullable()
        {
            // Определить несколько локальных переменных, допускающих null, с применением Nullable<T>.
            Nullable<int> nullableInt = 10;
            Nullable<double> nullableDouble = 3.14;
            Nullable<bool> nullableBool = null;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];

            // Ошибка! Строки являются ссылочными типами!
            //string? s = "oops";
        }

        // null-условная операция (суффикс - ?).
        static void TesterMethod(string[] args)
        {
            // Перед доступом к данным массива мы должны проверить его на равенство null!
            if (args != null)
            {
                Console.WriteLine($"You sent me {args.Length} arguments.");
            }

            // Мы должны проверять на предмет null перед доступом к данным массива!
            Console.WriteLine($"You sent me {args?.Length} arguments.");

            // null-услованя операция с объединением с null
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }
    }
}
