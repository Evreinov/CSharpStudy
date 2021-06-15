namespace Shapes
{
    // Абстрактный базовый класс иерархии.
    abstract class Shape
    {
        public Shape(string name = "NoName") { PetName = name; }

        public string PetName { get; set; }

        // Единственный виртуальный метод.
        //public virtual void Draw()
        //{
        //    Console.WriteLine("Inside Shape.Draw()");
        //}
        
        // Вынудить все дочерние классы определять способ своей визуализации.
        // (абстрактынй метод, может быть только в абстрактном классе)
        public abstract void Draw();
    }
}
