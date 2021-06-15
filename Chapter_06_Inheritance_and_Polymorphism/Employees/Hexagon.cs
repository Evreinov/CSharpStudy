using System;

namespace Employees
{
    class Hexagon
    {
        public Hexagon() { }
        public Hexagon(string name) 
        {
            PetName = name;
        }
        public string PetName { get; set; }
        public void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
}
