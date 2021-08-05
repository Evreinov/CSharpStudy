using System;

namespace SimpleFinalize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit the return key to shut down this app");
            Console.WriteLine("and force the GC to invoke Finalize()");
            Console.WriteLine("for finalizable objects created in this AppDomain.");

            // Нажмите клавишу <Enter>, чтобы завершить приложение
            // и заставить сборщик мусора вызвать метод Finalize()
            // для всех финализируемых объектов, которые
            // были созданы в домене этого приложения.
            Console.ReadLine();
            MyResourceWrapper rw = new MyResourceWrapper();
        }
    }
}
