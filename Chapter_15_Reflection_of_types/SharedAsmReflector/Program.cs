using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace SharedAsmReflector
{
    class Program
    {
        private static void DisplayInfo(Assembly a)
        {
            Console.WriteLine("***** Info about Assembly *****");
            Console.WriteLine("Load from GAC? {0}", a.GlobalAssemblyCache); // загружена из GAC?
            Console.WriteLine("Asm Name: {0}", a.GetName().Name); // Имя сборки.
            Console.WriteLine("Asm Version: {0}", a.GetName().Version); // Версия сборки.
            Console.WriteLine("Asm Culture: {0}", a.GetName().CultureInfo.DisplayName); // Культура сборки.
            Console.WriteLine("\nHere are the public enums:"); // Список открытых перечислений.
            // Использовать запрос LINQ для нахождения открытых перечислений.
            Type[] types = a.GetTypes();
            var publicEnums = from pe in types where pe.IsEnum && pe.IsPublic select pe;
            foreach (var pe in publicEnums)
            {
                Console.WriteLine(pe);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** The Shared Asm Reflector App *****\n");
            // Загрузить System.Windows.Forms.dll из GAC.
            string displayName = null;
            displayName = "System.Windows.Forms," +
                "Version=4.0.0.0," +
                "PublicKeyToken=b77a5c561934e089," +
                @"Culture=""";
            Assembly asm = Assembly.Load(displayName);
            DisplayInfo(asm);
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
