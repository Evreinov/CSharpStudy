using System;

/// <summary>
/// Ограничения параметров типа.
/// Примеры использования ключевого слова where.
/// </summary>
namespace GenericPoint
{
    /// <summary>
    /// Класс MyGenericClass является производным от object, в то время как
    /// содержащиеся в нем элементы должны иметь стандартный конструктор.
    /// </summary>
    public class MyGenericClass<T> where T : new()
    {
        // Этот метод меняет местами любые структуры, но не классы.
        static void Swap<K> (ref K a, ref K b) where K : struct { }
    }

    /// <summary>
    /// Класс MyGenericClass является производным от object, в то время как
    /// содержащиеся в нем элементы должны относиться к классу, реализующему 
    /// интерфейс ICloneable, и поддерживать стандартный конструктор.
    /// Ограничение new() должно указываться последним!
    /// </summary>
    public class MyGenericClass2<T> where T : class, ICloneable, new()
    {
    }

    /// <summary>
    /// Ошибка! Ограничение new() должно быть последним в списке!
    /// </summary>
    //public class MyGenericClass2<T> where T : new(), class, ICloneable
    //{
    //}

    /// <summary>
    /// Тип K должен расширять Random и иметь стандартный конструктор,
    /// в то время как тип <T> должен быть структурой и реализовывать
    /// обобщенный интерфейс IComparable.
    /// </summary>
    public class MyGenericClass<K, T> where K : Random, new()
        where T : struct, IComparable<T>
    {
    }
}