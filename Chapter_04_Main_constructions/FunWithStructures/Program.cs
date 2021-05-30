using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures
{
    struct Point
    {
        // Поля структуры
        public int X;
        public int Y;

        // Специальный конструктор
        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Добавить 1 к позиции (X, Y).
        public void Increment()
        {
            X++; Y++;
        }

        // Вычесть 1 из позиции (X, Y).
        public void Decrement()
        {
            X--; Y--;
        }

        // Отобразить текущую позицию.
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Structures *****\n");
            // Создать начальную переменную типа Point.
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();
            // Скоректировать значения X и Y.
            myPoint.Increment();
            myPoint.Display();

            // Ошибка! Полю Y не присвоено значение.
            //Point p1;
            //p1.X = 10;
            //p1.Display();

            // Все в порядке! Перед использованием значения присвоены обоим полям.
            Point p2;
            p2.X = 10;
            p2.Y = 10;
            p2.Display();

            // Установить для всех полей стандартные значения,
            // используя стандартный конструктор.
            Point p1 = new Point();
            // Выводит X=0, Y=0
            p1.Display();

            // Вызвать специальный конструктор.
            Point p3 = new Point(50, 60);
            // Выводит X=50, Y=60
            p3.Display();

            Console.ReadLine();
        }
    }
}
