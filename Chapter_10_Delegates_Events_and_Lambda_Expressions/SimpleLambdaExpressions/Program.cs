using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            Console.ReadLine();
        }

        /// <summary>
        /// Использование объектов делегатов.
        /// </summary>
        static void TraditionalDelegateSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Вызвать FindAll() с применением традиционного синтаксиса делегатов.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        // Цель для делегата Predicate<>.
        static bool IsEvenNumber(int i)
        {
            // Это четное число?
            return (i % 2) == 0;
        }

        /// <summary>
        /// Использование анонимного метода.
        /// </summary>
        static void AnonymousMethodSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Теперь использовать анонимный метод.
            List<int> evenNumbers = list.FindAll(
                delegate (int i) 
                {
                    return (i % 2) == 0;
                }
            );
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Синтаксис лямбда-выражений.
        /// </summary>
        static void LambdaExpressionSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Теперь использовать лямбда-выражение C#.
            //List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
            // Обработка аргументов внутри множества операторов.
            // Обработать каждый аргумент внутри группы опереаторов кода.
            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);// Текущее значение i.
                bool isEven = (i % 2) == 0;
                return isEven;
            });
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
    }
}
