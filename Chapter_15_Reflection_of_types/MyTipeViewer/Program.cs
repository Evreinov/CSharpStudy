using System;
// Это пространство имен должно импортироваться для выполнения любой рефлексии!
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTipeViewer
{
    class Program
    {
        // Для рефлексии обобщенных типов, нужно передать строку:
        // System.Collections.Generic.List`1
        // System.Collections.Generic.Dictionary`2
        // Цифра после обратной одинарной ковычки (`) означает количество параметров типа.
        // List<T> - один тип T.
        // Dictionary<TKey, TValue> - два типа TKey и TValue.
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName = "";

            do
            {
                Console.WriteLine("\nEnter a type name to evaluate"); // Предложить ввести имя типа.
                Console.Write("or enter Q to quit:"); // Или Q для завершения.
                // Получить имя типа.
                typeName = Console.ReadLine();

                // Пользователь желает завешить программу?
                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Попробовать отобразить информацию о типе.
                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find type"); // Не удалось найти тип.
                }

            } while (true);
        }

        /// <summary>
        /// Рефлексия методов.
        /// Отобразить имена методов в типе.
        /// </summary>
        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            //MethodInfo[] mi = t.GetMethods();
            //foreach (MethodInfo m in mi)
            //    Console.WriteLine("->{0}", m.Name);

            // LINQ
            //var methodNames = from n in t.GetMethods() select n.Name;
            //foreach (var name in methodNames)
            //    Console.WriteLine("->{0}", name);

            // Рефлексия параметров и возвращаемых значений методов.
            //MethodInfo[] mi = t.GetMethods();
            //foreach (MethodInfo m in mi)
            //{
            //    // Получить информацию о возвращаемом типе.
            //    string retVal = m.ReturnType.FullName;
            //    string paramInfo = "(";

            //    // Получить информацию о параметрах.
            //    foreach (ParameterInfo pi in m.GetParameters())
            //    {
            //        paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
            //    }
            //    paramInfo += ")";

            //    // Отобразить базовую сигнатуру метода.
            //    Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
            //}

            // Рефлексия параметров и возвращаемых значений методов LINQ.
            var methodsNames = from n in t.GetMethods() select n;
            foreach (var name in methodsNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }

        /// <summary>
        /// Рефлексия полей.
        /// Отобразить имена полей в типе.
        /// </summary>
        static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }

        /// <summary>
        /// Рефлексия свойств.
        /// Отобразить имена свойств в типе.
        /// </summary>
        static void ListProps(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }

        /// <summary>
        /// Рефлексия реализованных интерфейсов.
        /// Вывести имена любых интерфейсов, поддерживаемых входным типом.
        /// </summary>
        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine("->{0}", i.Name);
        }

        /// <summary>
        /// Отображение разнообразных дополнительных деталей.
        /// </summary>
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t?.BaseType); // Базовый класс.
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract); // Абстрактный?
            Console.WriteLine("Is type sealed? {0}", t.IsSealed); // Запечатанный? 
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition); // Обобщенный?
            Console.WriteLine("Is type a class type? {0}", t.IsClass); // Класс?
            Console.WriteLine();
        }
    }
}
