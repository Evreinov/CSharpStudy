// Выполнение рефлексии атрибутов с использованием раннего связывания.
using AttributedCarLibrary;
using System;

namespace VehickeDescriptionAttributeReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectOnAttributesUsingEarlyBinding();
            Console.ReadLine();
        }

        private static void ReflectOnAttributesUsingEarlyBinding()
        {
            // Получить объект Type, представляющий тип Winnebago.
            Type t = typeof(Winnebago);

            // Получить все атрибуты Winnebago.
            object[] customAtts = t.GetCustomAttributes(false);

            // Вывести описание.
            foreach (VehicleDescriptionAttribute v in customAtts)
                Console.WriteLine("-> {0}\n", v.Description);
        }
    }
}
