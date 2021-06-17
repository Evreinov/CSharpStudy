using System;

namespace CustomInterface
{
    class ThreeDCircle : Circle, IDraw3D
    {
        // Скрыть свойство PetName, опеределенное выше в иерархии.
        public new string PetName { get; set; }
        // Скрыть любую реализацию Draw(), находящуюся выше в иерархии.
        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }
        // Circle поддерживает IDraw3D
        public void Draw3D()
        {
            Console.WriteLine("Drawing Circle in 3D!");
        }
    }
}
