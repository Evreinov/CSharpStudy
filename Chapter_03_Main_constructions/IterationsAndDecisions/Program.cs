using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ForLoopExample();
            //ForEachExample();
            //LinqQueryOverInts();
            //WhileLoopExample();
            //DoWhileLoopExample();
            //IfElseExample();
            //ExecuteIfElseUsingCinditionalOperator();
            //SwitchExample();
            //SwitchOnStringExample();
            //SwitchOnEnumExample();
            ExecutePatternMatchingSwitch();
            ExecutePatternMatchingSwitchWithWhen();
            Console.ReadLine();
        }

        /// <summary>
        /// Базовый цикл for.
        /// </summary>
        static void ForLoopExample()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Number is: {0} ", i);
            }
            // Здесь переменная i больше видимой не будет
        }

        /// <summary>
        /// Проход по элементам массива посредством foreach
        /// </summary>
        static void ForEachExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string c in carTypes)
                Console.WriteLine(c);

            int[] myInts = { 10, 20, 30, 40 };
            foreach (var i in myInts)
                Console.WriteLine(i);
        }

        /// <summary>
        /// Использование неявной типизации в конструкции foreach
        /// </summary>
        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Запрос LINQ!
            var subset = from i in numbers where i < 10 select i;
            Console.WriteLine("Values in subset: ");

            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
        }

        /// <summary>
        /// Цикл while
        /// </summary>
        static void WhileLoopExample()
        {
            string userIsDone = "";
            // Проверить копию строки в нижнем регистре
            while (userIsDone.ToLower() != "yes")
            {
                Console.WriteLine("In while loop");
                Console.WriteLine("Are you done? [yes] [no]: "); // Запрос продолжнения
                userIsDone = Console.ReadLine();
            }
        }

        /// <summary>
        /// Цикл do/while
        /// </summary>
        static void DoWhileLoopExample()
        {
            string userIsDone = " ";
            // Проверить копию строки в нижнем регистре
            do
            {
                Console.WriteLine("In do/while loop");
                Console.WriteLine("Are you done? [yes] [no]: "); // Запрос продолжнения
                userIsDone = Console.ReadLine();
            } while (userIsDone.ToLower() != "yes"); // Обратите внимание на точку с запятой!
        }

        /// <summary>
        /// Оператор if/else
        /// </summary>
        static void IfElseExample()
        {
            string stringData = "My textual data";
            if (stringData.Length > 0)
            {
                // Строка длинее 0 символов
                Console.WriteLine("string is greter than 0 characters");
            }
            else
            {
                // Строка не длинее 0 символов
                Console.WriteLine("string is not greter than 0 characters");
            }
            // Операции && и || при необходимости поддерживают сокращенный путь выполнения.
            // Другими словами, после того, как было определено, что сложное выражение должно дать в результате
            // false, оставшиеся подвыражения вычислять не будут. Если требуется,
            // чтобы все выражения вычислялилсь безотносительно к чему-либо, тогда нужно использовать операции & и |
        }

        /// <summary>
        /// Условная операция (?:)
        /// условие ? первое_выражение : второе_выражение
        /// </summary>
        static void ExecuteIfElseUsingCinditionalOperator()
        {
            string stringData = "My textual data";
            Console.WriteLine(stringData.Length > 0
                ? "string is greter than 0 characters" 
                : "string is not greter than 0 characters");

            // Ниженаписанный код приведет к ошибке, нет присваивания
            //stringData.Length > 0
            //    ? Console.WriteLine("string is greter than 0 characters")
            //    : Console.WriteLine("string is not greter than 0 characters");
        }

        /// <summary>
        /// Оператор switch
        /// </summary>
        static void SwitchExample()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.WriteLine("Please pick your language preference: "); // Выберите предпочитаемый язык:
            string langChoice = Console.ReadLine();
            int n = int.Parse(langChoice);
            switch (n)
            {
                case 1:
                    Console.WriteLine("Good choice, C# is a fine language."); // Хороший выбор. C# - замечательный язык.
                    break;
                case 2:
                    Console.WriteLine("VB: OOP, multithreading, and more!"); // VB: ООП, многопоточность и многое другое!
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!"); // Хорошо, удачи с этим!
                    break;
            }
        }

        /// <summary>
        /// Оператор switch, который оценивает переменную типа string 
        /// </summary>
        static void SwitchOnStringExample()
        {
            Console.WriteLine("C# or VB");
            Console.WriteLine("Please pick your language preference: "); // Выберите предпочитаемый язык:
            string langChoice = Console.ReadLine();
            switch (langChoice)
            {
                case "C#":
                    Console.WriteLine("Good choice, C# is a fine language."); // Хороший выбор. C# - замечательный язык.
                    break;
                case "VB":
                    Console.WriteLine("VB: OOP, multithreading, and more!"); // VB: ООП, многопоточность и многое другое!
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!"); // Хорошо, удачи с этим!
                    break;
            }
        }

        /// <summary>
        /// Оператор switch для перечислений enum
        /// </summary>
        static void SwitchOnEnumExample()
        {
            Console.WriteLine("Enter your favorite day of week: "); // Введите любимый день недели
            DayOfWeek favDay;

            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bad input!"); // Недопустимое входное значение!
                return;
            }

            switch (favDay)
            {
                case DayOfWeek.Sunday:
                    Console.WriteLine("Football!!"); // Футбол
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("Another day, another dollar."); // Ещё один день, ещё один доллар.
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("At least it is Monday."); // Во всяком случае, не понедельник.
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("A fine day."); // Хороший денек.
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Almost Friday..."); // Почти пятница
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Yes, Friday rules!"); // Да, пятница рулит!
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Great day indeed."); // Действительно великолепный день.
                    break;
                // Сквозной проход
                //case DayOfWeek.Saturday:
                //case DayOfWeek.Sunday:
                //    Console.WriteLine("It's the weekend!"); // Выходные
                //    break;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Оператор switch с goto (антипаттерн)
        /// </summary>
        public static void SwitchWithCoto()
        {
            var foo = 5;
            switch(foo)
            {
                case 1:
                    // Делать что-то
                    goto case 2;
                case 2:
                    // Делать что-то другое
                    break;
                case 3:
                    // Ещё одно действие
                    goto default;
                default:
                    // Стандартное действие
                    break;
            }
        }

        /// <summary>
        /// Оператор switch, использование сопоставления с образцом.
        /// </summary>
        static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.WriteLine("Please choose an option: ");
            string userChoise = Console.ReadLine();
            object choice;

            // Стандартный оператор switch, в котором применяется
            // сопоставление с образцом с константами
            switch (userChoise)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = 5;
                    break;
            }

            // Новый оператор switch, в котором применяется
            // сопоставление с образцом с типами

            switch (choice)
            {
                case int i:
                    Console.WriteLine("Your choice is an integer {0}.", i); // Выбрано целое число
                    break;
                case string s:
                    Console.WriteLine("Your choice is an string {0}.", s); // Выбрана строка
                    break;
                case decimal d:
                    Console.WriteLine("Your choice is an decimal {0}.", d); // Выбрано десятичное число
                    break;
                default:
                    Console.WriteLine("Your choice is something else"); // Выбрано что-то другое
                    break;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Оператор switch, с добавление конструкции when
        /// </summary>
        static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.WriteLine("Please pick your language preference: ");

            object langChoice = Console.ReadLine();
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;

            switch (choice)
            {
                case int i when i == 2:
                case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!"); // VB: ООП, многопоточность и многое другое!
                    break;
                case int i when i == 1:
                case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language."); // Хороший выбор. C# - замечательный язык.
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!"); // Хорошо, удачи с этим!
                    break;
            }
            Console.WriteLine();

            // Иногда порядок важен, здесь совпадение будет всегда в первоми операторе case,
            // а второй и третий оператор case никогда не выполнится
            //switch (choice)
            //{
            //    case int i:
            //        // Делать что-то
            //        break;
            //    case int i when i == 0:
            //        // Делать что-то
            //        break;
            //    case int i when i == -1:
            //        // Делать что-то
            //        break;
            //}
        }
    }
}
