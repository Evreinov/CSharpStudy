using System;

namespace ValueAndReferenceTypes
{
    #region Struct - тип значения
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
    #endregion

    #region Class - ссылочный тип
    class PointRef
    {
        // Поля структуры
        public int X;
        public int Y;

        // Специальный конструктор
        public PointRef(int XPos, int YPos)
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
    #endregion

    #region Тип значения, содержащий ссылочный тип.
    class ShapeInfo
    {
        public string InfoString;
        public ShapeInfo(string info)
        {
            InfoString = info;
        }
    }
    
    struct Rectangle
    {
        // Структруа Rectangle содержит член ссылочного типа
        public ShapeInfo RectInfo;
        public int RectTop, RectLeft, RectBotton, RectRight;
        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            RectInfo = new ShapeInfo(info);
            RectTop = top;
            RectLeft = left;
            RectBotton = bottom;
            RectRight = right;
        }
        public void Display()
        {
            Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, Left = {3}, Right = {4}",
                RectInfo.InfoString, RectTop, RectBotton, RectLeft, RectRight);
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            ValueTypesAssignment();
            Console.ReadLine();
            ReferenceTypeAssignment();
            Console.ReadLine();
            ValueTypeContainingRefType();
            Console.ReadLine();
        }

        // Присвоение двух внутренних типов значений дает
        // в результате две независимые переменные в стеке.
        static void ValueTypesAssignment()
        {
            Console.WriteLine("Assigning value types\n");

            Point p1 = new Point(10, 10);
            Point p2 = p1;

            // Вывести значения обеих переменных Point.
            p1.Display();
            p2.Display();

            // Изменить p1.X и снова вывести значения переменных. Значение p2.X не изменилось.
            p1.X = 100;
            Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();
        }

        static void ReferenceTypeAssignment()
        {
            Console.WriteLine("Assigning reference types\n");

            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;

            // Вывести значения обеих переменных PointRef.
            p1.Display();
            p2.Display();

            // Изменить p1.X и снова вывести значения переменных. Значение p2.X изменилось.
            p1.X = 100;
            Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();
        }

        static void ValueTypeContainingRefType()
        {
            // Создать первую переменную Rectangle.
            Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);
            // Присвоить новой переменной Rectangle переменную r1.
            Console.WriteLine("-> Assigning r2 to r1");
            Rectangle r2 = r1;
            // Изменить некоторые значения в r2.
            Console.WriteLine("-> Changing values of r2");
            r2.RectInfo.InfoString = "This is new info!";
            r2.RectBotton = 4444;
            // Вывести значения из обеих переменных Rectangle.
            r1.Display();
            r2.Display();
        }
    }
}
