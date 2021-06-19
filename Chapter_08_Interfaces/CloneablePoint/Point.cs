using System;

namespace CloneablePoint
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();

        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public Point() { }

        public override string ToString() => $"X = {X}; Y = {Y}; Name = {desc.PetName};\nID = {desc.PointID}\n";

        // Возвратить копию текущего объекта.
        // public object Clone() => new Point(this.X, this.Y);

        // Т.к. Point не содержит ссылочные типы, метод Clone()
        // можно упростить используя поверхностную копию.
        // public object Clone() => this.MemberwiseClone();

        // Более сложный пример клонирования, когда Point
        // содержит ссылочные типы.
        public object Clone()
        {
            // Сначала получить поверхностную копию.
            Point newPoint = (Point)this.MemberwiseClone();

            // Затем восполнить пробелы.
            PointDescription currentDesc = new PointDescription();
            currentDesc.PetName = this.desc.PetName;
            newPoint.desc = currentDesc;
            return newPoint;
        }
    }
}
