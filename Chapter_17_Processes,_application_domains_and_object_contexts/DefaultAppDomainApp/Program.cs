using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDAD();
            Console.WriteLine("***** Fun with th default AppDomain *****\n");
            DisplayDADStats();
            Console.WriteLine();
            ListAllAssembliesInAppDomain();
            Console.ReadLine();
        }

        /// <summary>
        /// Взаимодействие со стандартным доменом приложения.
        /// </summary>
        private static void DisplayDADStats()
        {
            // Получить доступ к домену приложения для текущего потока.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Вывести разнообразные статические данные об этом домене.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName); // Дружественное имя.
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id); // Идентификатор.
            Console.WriteLine("Is this the default domain?: {0}", defaultAD.IsDefaultAppDomain()); // Является ли стандартным.
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory); // Базовый каталог.
        }

        /// <summary>
        /// Перечисление загруженных сборок.
        /// </summary>
        static void ListAllAssembliesInAppDomain()
        {
            // Получить доступ к домену приложения для текущего потока.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Извлечь все сборки, загруженные в стандартный домен приложения.
            //Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            // LINQ
            var loadedAssemblies = from a in defaultAD.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", defaultAD.FriendlyName);
            foreach (Assembly a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name); // Имя.
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version); // Версия.
            }
        }

        /// <summary>
        /// Получить уведомление о загрузке сборок.
        /// </summary>
        private static void InitDAD()
        {
            // Эта логика будет выводить имя любой сборки, загруженной
            // в домен приложения после его создания.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }
    }
}
