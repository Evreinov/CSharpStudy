namespace InterfaceNameClash
{
    // Вывести изображение на форму.
    public interface IDrawToForm
    {
        void Draw();
    }

    // Вывести изображение в буфер памяти.
    public interface IDrawToMemory
    {
        void Draw();
    }

    // Вывести изображение на принтер.
    public interface IDrawToPrinter
    {
        void Draw();
    }
}
