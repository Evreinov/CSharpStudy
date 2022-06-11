using System;
using System.IO;

namespace SimpleFileIO
{
    internal class Program
    {
        /// <summary>
        /// Работа с типом File. (Аналогичный класс есть, FileInfo;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = {"Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Xbox One"};

            // Записать все данные в файл на диске С:.
            File.WriteAllLines(@"tasks.txt", myTasks);

            // Прочитать все данные и вывести на консоль.
            foreach (string task in File.ReadAllLines(@"tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }

            Console.ReadLine();
        }
    }
}
