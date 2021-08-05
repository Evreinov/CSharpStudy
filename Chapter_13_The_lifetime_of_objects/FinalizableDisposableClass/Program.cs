using System;

namespace FinalizableDisposableClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter *****");

            // Вызвать метод Dispose() вручную. Это не приведет к вызову финализатора.
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            // Не вызывать метод Dispose(). Это приведет к вызову финализатора
            // и выдаче звукового сигнала.
            MyResourceWrapper rw2 = new MyResourceWrapper();
        }
    }
}
