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
            ExecutePatternMatchingSwitch();
            Console.ReadLine();
            ExecutePatternMatchingSwitchWithWhen();
            Console.ReadLine();
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
