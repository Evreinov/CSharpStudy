using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;

namespace LateBindingApp
{   
    /// <summary>
    /// Это приложение будет загружать внешнюю сборку и 
    /// создавать объект, используя позднее связывание.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding *****");
            // Попробовать загрузить локальную копию CarLibrary.
            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (a != null)
            {
                CreateUsingLateBinding(a);
                InvokeMethodWithArgsUsingLateBinding(a);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Класс System.Activator и вызов метода без параметров.
        /// </summary>
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа MiniVan.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Создать экземпляр MiniVan на лету.
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding!", obj);

                // Получить информацию о TurboBoost
                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                // Вызвать метод (null означает отсутствие параметров).
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Вызов метода с параметрами.
        /// </summary>
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить описание метаданных для типа SportsCar.
                Type sport = asm.GetType("CarLibrary.SportsCar");

                // Создать объект типа SportsCar.
                object obj = Activator.CreateInstance(sport);

                // Вызвать метод TurnOnRadio() с аргументами.
                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
