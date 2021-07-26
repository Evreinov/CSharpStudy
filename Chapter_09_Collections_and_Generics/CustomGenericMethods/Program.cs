using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Generic Methods *****\n");

            // Обмен двух целочисленных значений.
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: {0}, {1}", a, b);
            Console.WriteLine();

            // Обмен двух строковых значений.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0}, {1}", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0}, {1}", s1, s2);
            Console.WriteLine();

            // Компилятор выведит все равно тип System.Boolean.
            bool b1 = true, b2 = false;
            Console.WriteLine("Before swap: {0}, {1}", b1, b2);
            Swap(ref b1, ref b2); // Параметр типа можно упустить, если обобщенный метод принимает аргументы.
                                  // Но это не желательно, т.к. сразу не определить, является ли вызываемый метод обобщенным.
            Console.WriteLine("After swap: {0}, {1}", b1, b2);
            Console.WriteLine();

            // Если метод не принимает параметров,
            // то должен быть указан параметр типа.
            DisplayBaseClass<int>();
            DisplayBaseClass<string>();
            // Ошибка на этапе компиляции! Нет параметров?
            // Должен быть предоставлен заполнитель!
            //DisplayBaseClass();

            MyGenericMethods.Swap<int>(ref a, ref b);

            Console.ReadLine();
        }

        /// <summary>
        /// Этот метод будет менять местами два элемента
        /// типа, указанного в параметре <T>.
        /// </summary>
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Обобщенный метод не принимает, не один параметр.
        /// </summary>
        static void DisplayBaseClass<T>()
        {
            // BaseType - метод, используемый в рефлексии.
            Console.WriteLine("Base class of {0} is: {1}", typeof(T), typeof(T).BaseType);
        }
    }
}
