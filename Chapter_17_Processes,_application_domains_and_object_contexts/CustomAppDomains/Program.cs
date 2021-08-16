using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CustomAppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom AppDomains *****\n");
            // Вывести все сборки, загруженные в стандартный домен приложения.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            defaultAD.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AD unloaded!");
                // Стандартный домен приложения выгружен!
            };
            ListAllAssembliesInAppDomain(defaultAD);

            // Создать новый домен приложения.
            MakeNewAppDomain();
            Console.ReadLine();
        }

        /// <summary>
        /// Создание нового специального домена.
        /// Загрузка сборки CarLibrary.dll в специальный домен.
        /// Выгрузка домена.
        /// </summary>
        private static void MakeNewAppDomain()
        {
            // Создать новый домен приложения в текущем процессе
            // и вывести список загруженных сборок.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The second AppDomain has been unloaded!");
                // Второй домен приложения выгружен!
            };
            try
            {
                // Загрузить CarLibrary.dll в этот новый домен.
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Вывести список сборок.
            ListAllAssembliesInAppDomain(newAD);
            // Избаиться от этого домена приложения!
            AppDomain.Unload(newAD);
        }

        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            // Получить все сборки, загруженные в стандартный домен приложения.
            var loadedAssemblies = from a in ad.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", ad.FriendlyName);
            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name); // Имя.
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version); // Версия.
            }
        }
    }
}
