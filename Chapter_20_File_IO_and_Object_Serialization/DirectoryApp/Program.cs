using System;
using System.IO;

namespace DirectoryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(info) *****\n");
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            ModifyAppDirectory();
            ModifyAppDirectory2();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            // Вывести информацию о каталоге.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName); // Полное имя
            Console.WriteLine("Name: {0}", dir.Name); // имя катталога
            Console.WriteLine("Parent: {0}", dir.Parent); // родительский каталог
            Console.WriteLine("Creation: {0}", dir.CreationTime); // время создания
            Console.WriteLine("Attributes: {0}", dir.Attributes); // атрибуты
            Console.WriteLine("Root: {0}", dir.Root); // корневой каталог
            Console.WriteLine("**************************\n");
        }

        /// <summary>
        /// Перечисление файлов с помощью типа DirectoryInfo.
        /// </summary>
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            // Получить все файлы с расширением *.jpg.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            // Сколько файлов найдено.
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            // Вывести информацию о каждом файле.
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("**************************");
                Console.WriteLine("File name: {0}", f.Name); // имя файла
                Console.WriteLine("File size: {0}", f.Length); // размер
                Console.WriteLine("Creation: {0}", f.CreationTime); // время создания
                Console.WriteLine("Attributes: {0}", f.Attributes); // атриубыт
                Console.WriteLine("**************************\n");
            }
        }

        /// <summary>
        /// Создание подкаталогов с помощью типа DirectoryInfo.
        /// </summary>
        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");

            // Создать \MyFolder в каталоге приложения.
            dir.CreateSubdirectory("MyFolder");

            // Создать \MyFolder2\Data в каталоге приложения.
            dir.CreateSubdirectory(@"MyFolder2\Data");
        }

        /// <summary>
        /// Создание подкаталогов с помощью типа DirectoryInfo.
        /// </summary>
        /// <remarks>
        /// Показывает, что CreateSubdirectory() возвращает DirectoryInfo в случаи успешного выполнения.
        /// </remarks>
        static void ModifyAppDirectory2()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            // Создать \MyFolder в начальном каталоге.
            dir.CreateSubdirectory("MyFolder");

            // Получить возвращаемый объект DirectoryInfo.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

            // Выводит путь к ..\MyFolder2\Data
            Console.WriteLine("New Folder is: {0}", myDataFolder);
        }
    }
}
