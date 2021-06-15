using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ThreeDCircle : Circle
    {
        // Скрыть свойство PetName, опеределенное выше в иерархии.
        public new string PetName { get; set; }
        // Скрыть любую реализацию Draw(), находящуюся выше в иерархии.
        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }
    }
}
