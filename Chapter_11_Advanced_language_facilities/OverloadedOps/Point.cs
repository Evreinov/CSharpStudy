using System;

namespace OverloadedOps
{
    // Простой будничный класс C#.
    class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString() => $"[{this.X}, {this.Y}]";

        // Перегруженная операция +.
        public static Point operator + (Point p1, Point p2) =>
            new Point(p1.X + p2.X, p1.Y + p2.Y);

        // Перегруженная операция -.
        public static Point operator - (Point p1, Point p2) =>
            new Point(p1.X - p2.X, p1.Y - p2.Y);

        // Передавать два опереатора одного и тогоже типа не обязательно.
        public static Point operator + (Point p1, int change) =>
            new Point(p1.X + change, p1.Y + change);

        public static Point operator + (int change, Point p1) =>
            new Point(p1.X + change, p1.Y + change);

        // Перегрузка унарных операции ++ и --.
        // Добавить 1 к значениям X/Y входного объекта Point.
        public static Point operator ++(Point p1) =>
            new Point(p1.X + 1, p1.Y + 1);

        // Вычесть 1 из значений X/Y входного объекта Point.
        public static Point operator --(Point p1) =>
            new Point(p1.X - 1, p1.Y - 1);

        // Перегрузка операций эквивалентности.
        public override bool Equals(object o) => o.ToString() == this.ToString();

        public override int GetHashCode() => this.ToString().GetHashCode();

        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);

        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);

        // Перегрузка операций сравнения.
        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
                return 1;
            if (this.X < other.X && this.Y < other.Y)
                return -1;
            else
                return 0;
        }

        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;
    }
}
