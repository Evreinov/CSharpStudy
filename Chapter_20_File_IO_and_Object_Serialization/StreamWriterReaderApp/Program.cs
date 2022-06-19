using System;
using System.IO;

namespace StreamWriterReaderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");

            // Получить объект StreamWriter и записать строковые данные.
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            // Аналогично using (StreamWriter writer = new StreamWriter("reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                writer.WriteLine("Don't forget these numbers:");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }
                // Вставить новую строку.
                writer.Write(writer.NewLine);
            }

            Console.WriteLine("Created file and wrote some thoughts...");
            Console.ReadLine();

            // Прочитать данные из файла.
            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader sr = File.OpenText("reminders.txt"))
            // Аналогчино using (StreamReader sr = new StreamReader("reminders.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }

            Console.ReadLine();
        }
    }
}
