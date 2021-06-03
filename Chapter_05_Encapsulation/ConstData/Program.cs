using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class MyMathClass
    {
        public const double PI = 3.14; // Константа класса, является неявно статической.
        // Допустимо определять локальные константные данные, в отличии от статических данных.
        static void LocalConstStringVariable()
        {
            const string fixedStr = "Fixed string Data";
            Console.WriteLine(fixedStr);
        }

        // Поля только для чтения могут присваиваться 
        // в конструкторах, но больше нигде.
        public readonly double Pi;
        public MyMathClass()
        {
            Pi = 3.14;
        }
        // Ошибка!
        //public void ChangePi()
        //{
        //    Pi = 3.15;
        //}

        // Статическое поле, допускающее только чтение
        public static readonly double pi;
        static MyMathClass()
        {
            pi = 3.14;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Const *****\n");
            Console.WriteLine("The value of PI is {0}", MyMathClass.pi);
            // Ошибка! Константу изменять нельзя!
            //MyMathClass.PI = 3.1415;
            Console.ReadLine();
        }
    }
}
