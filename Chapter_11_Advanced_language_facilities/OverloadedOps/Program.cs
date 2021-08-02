using System;

namespace OverloadedOps
{
    class Program
    {
        // Сложение и вычетание двух точек?
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Overloaded Operators *****\n");

            // Создать две точки.
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 40);
            Console.WriteLine("ptOne = {0}", ptOne);
            Console.WriteLine("ptTwo = {0}", ptTwo);

            // Сложить две точки, чтобы получить большую?
            Console.WriteLine("ptOne + ptTwo: {0}", ptOne + ptTwo);

            // Вычесть одну точку из другой, чтобы получить меньшую?
            Console.WriteLine("ptOne - ptTwo: {0}", ptOne - ptTwo);

            // Выводит [110, 110]
            Point biggerPoint = ptOne + 10;
            Console.WriteLine("ptOne + 10 = {0}", biggerPoint);

            // Выводит [120, 120]
            Console.WriteLine("10 + biggerPoint = {0}", 10 + biggerPoint);
            Console.WriteLine();

            // Перегрузка бинарных операций автоматически обеспечивает
            // перегрузку сокращенных операций.

            // Операция += перегружена автоматически.
            Point ptThree = new Point(90, 5);
            Console.WriteLine("ptThree = {0}", ptThree);
            Console.WriteLine("ptThree += ptTwo: {0}", ptThree += ptTwo);

            // Операция -= перегружена автоматически.
            Point ptFour = new Point(0, 500);
            Console.WriteLine("ptFour = {0}", ptFour);
            Console.WriteLine("ptFour -= ptThree: {0}", ptFour -= ptThree);
            Console.WriteLine();

            // Применение унарных операций ++ и -- к объекту Point.
            Point ptFive = new Point(1, 1);
            Console.WriteLine("++PtFive = {0}", ++ptFive);
            Console.WriteLine("--PtFive = {0}", --ptFive);

            // Применение тех же операций в виде постфиксного инкремента/декремента.
            Point ptSix = new Point(20, 20);
            Console.WriteLine("ptSix++ = {0}", ptSix++);
            Console.WriteLine("ptSix-- = {0}", ptSix--);
            Console.WriteLine();

            Console.WriteLine("ptOne == ptTwo: {0}", ptOne == ptTwo);
            Console.WriteLine("ptOne != ptTwo: {0}", ptOne != ptTwo);
            Console.WriteLine();

            // Использование перегруженных операций < и >.
            Console.WriteLine("ptOne < ptTwo : {0}", ptOne < ptTwo);
            Console.WriteLine("ptOne > ptTwo : {0}", ptOne > ptTwo);
            Console.ReadLine();
        }
    }
}
