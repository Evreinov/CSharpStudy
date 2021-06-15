using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Polymorphism *****");
            Hexagon hex = new Hexagon("Beth");
            hex.Draw();
            Circle cir = new Circle("Cindy");
            cir.Draw(); // Вызывает реализацию базового класса!
            Console.ReadLine();

            // Создать массив совместимых с Shape объектов.
            Shape[] myShapes = { new Hexagon(), new Circle(), new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda"), 
                new ThreeDCircle() }; // ThreeDCircle() - метод Draw() будет вызван родительского класса. 
            // Пройти в цикле по всем элементам и взаимодействовать
            // с полиморфным интерфейсом.
            foreach (Shape s in myShapes)
            {
                s.Draw();
            }
            Console.ReadLine();

            ThreeDCircle o = new ThreeDCircle();
            // Здесь вызывается метод Draw(), определенный в классе ThreeDCircle.
            o.Draw();
            // Здесь вызывается метод Draw(), определенный в родительском классе!
            ((Circle)o).Draw();
            Console.ReadLine();
        }
    }
}
