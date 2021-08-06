using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShapes;
using My3DShapes;
// Устранить неоднозначность с помощью специальных псевдонимов.
using The3DHexagon = My3DShapes.Hexagon;

namespace CustomNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Разрешение конфликвто имен с помощью заданных имен.
            MyShapes.Hexagon h = new MyShapes.Hexagon();
            MyShapes.Circle c = new MyShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();

            // На самом деле здесь создается экземпляр класса My3DShapes.Hexagon.
            The3DHexagon h2 = new The3DHexagon();
        }
    }
}
