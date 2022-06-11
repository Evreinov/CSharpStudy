using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with DriveInfo *****\n");

            // Получить информацию обо всех устройствах.
            DriveInfo[] myDrivers = DriveInfo.GetDrives();

            // Вывести сведения об устройствах.
            foreach (DriveInfo d in myDrivers)
            {
                Console.WriteLine("Name: {0}", d.Name); // имя
                Console.WriteLine("Type: {0}", d.DriveType); // тип

                // Проверить, смонтировано ли устройство.
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace); // свободное пространство
                    Console.WriteLine("Format: {0}", d.DriveFormat); // формат устройства
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
