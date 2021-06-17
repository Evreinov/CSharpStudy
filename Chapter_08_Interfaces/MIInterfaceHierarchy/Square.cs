namespace MIInterfaceHierarchy
{
    // Специфические реализации для каждого метода Draw().
    class Square : IShape
    {
        // Использование явной реализации для устранения конфликта имен членов.
        void IDrawable.Draw()
        {
            // Вывести на экран...
        }

        void IPrintable.Draw()
        {
            // Вывести на принтер...
        }

        int IShape.GetNumberOfSides() => 4;

        void IPrintable.Print()
        {
            // Печатать...
        }
    }
}
