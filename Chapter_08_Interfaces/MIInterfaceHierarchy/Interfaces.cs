namespace MIInterfaceHierarchy
{
    // Множественное наследования для интерфейсных типов допускается.
    interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Возможен конфликт имен!
    }

    // Множественное наследование интерфейсов. Разрешено!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
