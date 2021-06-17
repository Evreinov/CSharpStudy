namespace CustomInterface
{
    // Этот интерфейс определяет поведение "наличия вершин".
    public interface IPointy
    {
        // Все члены интерфейса являются неявно открытыми и абстрактными.
        //byte GetNumberOfPoints();
        byte Points { get; }
    }
}
