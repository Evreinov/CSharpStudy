using System;
using System.IO;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Dispose *****\n");
            // Создать освобождаемый объект и вызвать метод Dispose()
            // для освобождения любых внутренних ресурсов.
            MyResourceWrapper rw = new MyResourceWrapper();
            if (rw is IDisposable)
                rw.Dispose();
            Dispose1();
            Dispose2();
            Dispose3();
            Console.ReadLine();
        }

        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);

            // Вызовы этих методов делают одно и то же!
            fs.Close();
            fs.Dispose();
        }

        #region Использование ключевого слова using для Dispose().
        static void Dispose1()
        {
            Console.WriteLine("***** Fun with Dispose *****\n");
            MyResourceWrapper rw = new MyResourceWrapper();
            try
            {
                // Использовать члены rw
            }
            finally
            {
                // Всегда вызывать Dispose(), возникла ошибка или нет
                rw.Dispose();
            }
        }


        static void Dispose2()
        {
            Console.WriteLine("***** Fun with Dispose *****\n");
            // Метод Dispose() вызывается автоматически
            // при выходе за пределы области действия using.
            using (MyResourceWrapper rw = new MyResourceWrapper())
            {
                // Использовать объект rw.
            }
        } 

        static void Dispose3()
        {
            Console.WriteLine("***** Fun with Dispose *****\n");
            // Использовать список с разделителями-запятыми для объявления
            // нескольких объектов, подлежащих освобождению.
            using (MyResourceWrapper rw = new MyResourceWrapper(), rw2 = new MyResourceWrapper())
            {
                // Работать с объектами rw и rw2.
            }
        }
        #endregion
    }
}
