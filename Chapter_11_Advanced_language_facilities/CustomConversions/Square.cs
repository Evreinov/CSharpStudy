using System;

namespace CustomConversions
{
    public struct Square
    {
        public int Lenght { get; set; }

        public Square(int l) : this()
        {
            Lenght = l;
        }

        public void Draw()
        {
            for (int i = 0; i < Lenght; i++)
            {
                for (int j = 0; j < Lenght; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Lenght = {Lenght}]";

        //Rectangle можно явно преобразовать в Square.
        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square { Lenght = r.Height };
            return s;
        }

        public static explicit operator Square (int sideLength)
        {
            Square newSq = new Square { Lenght = sideLength };
            return newSq;
        }

        public static explicit operator int (Square s) => s.Lenght;
    }
}
