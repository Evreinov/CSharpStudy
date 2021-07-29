using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    /// <summary>
    /// Этот делегат может указывать на любой метод, который принимает
    /// два целочисленных значения и возвращает целочисленное значение.
    /// </summary>
    public delegate int BinaryOp(int x, int y);

    /// <summary>
    /// Этот класс содержит методы, на которые
    /// будет указывать BinaryOp.
    /// </summary>
    public class SimpleMath
    {
        public int Add(int x, int y) => x + y;
        public int SubTract(int x, int y) => x - y;
        public static int SquareNumber(int a) => a * a;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example ***** \n");

            // Создать объект делегата BinaryOp, который
            // "указывает" на SimpleMath.Add().
            SimpleMath m = new SimpleMath();
            BinaryOp b = new BinaryOp(m.Add);

            // вывести сведения об объекте.
            DisplayDelegateInfo(b);

            // Ошибка на этапе компиляции! Метод не соотвествует шаблону делегата!
            //BinaryOp b2 = new BinaryOp(SimpleMath.SquareNumber);

            // Вызвать метод Add() косвенно с использованием объекта делегата.
            // "За кулисами" исполняющая среда на самом деле вызывает сгенерированный
            // компилятором метод Invoke() на производном от MulticastDelegate.
            Console.WriteLine("10 + 10 is {0}", b(10, 10));
            // Явный вызов Invoke().
            Console.WriteLine("10 + 10 is {0}", b.Invoke(10, 10));

            Console.ReadLine();
        }

        /// <summary>
        /// Выводит на консоль имена методов, 
        /// поддерживаемых объетов делегата, а также имя класса.
        /// </summary>
        static void DisplayDelegateInfo(Delegate delObj)
        {
            // Вывести имена всех членов в списке вызова делегата.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method); // имя метода
                Console.WriteLine("Type Name: {0}", d.Target); // имя типа
            }
        }
    }
}
