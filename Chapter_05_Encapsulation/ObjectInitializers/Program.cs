using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Init Syntax *****\n");

            // Создать объект Point, устанавлия каждое свойство вручную.
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            // Создать объект Point посредством специального конструктора.
            Point anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();

            // Создать объект Point, используя синтаксис инициализации объектов.
            Point finalPoint = new Point { X = 30, Y = 30 };
            finalPoint.DisplayStats();

            // Здесь стандартный конструктор вызывается неявно.
            //Point finalPoint = new Point { X = 30, Y = 30 };
            // Здесь стандартный конструктор вызывается явно.
            //Point finalPoint = new Point() { X = 30, Y = 30 };
            // Вызов специального конструктора.
            Point pt = new Point(10, 16) { X = 100, Y = 100 }; // X и Y будут равны 100, не смотря на то,
                                                               // что в аргументах конструктора указано 10 и 16; 
            pt.DisplayStats();

            // Вызов более интересного специального конструктора
            // с помощью синтаксиса инициализации.
            Point goldPoint = new Point(PointColor.Gold) { X = 90, Y = 20 };
            goldPoint.DisplayStats();

            // Создать и инициализировать объект Rectangle.
            Rectangle myRect = new Rectangle
            {
                TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 200, Y = 200 }
            };
            // Традиционный подход.
            Rectangle r = new Rectangle();
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 10;
            r.TopLeft = p1;
            Point p2 = new Point();
            p2.X = 200;
            p2.Y = 200;
            r.BottomRight = p2;


            Console.ReadLine();
        }
    }
}
