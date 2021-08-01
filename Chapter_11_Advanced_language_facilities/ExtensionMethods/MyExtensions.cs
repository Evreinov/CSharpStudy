using System;
using System.Reflection;

// Расширяющие методы не глобальны, они ограничены пространством имён в котором определены.
namespace MyExtensionMethods
{
    static class MyExtensions
    {
        // Этот метод позволяет объекту любого типа
        // отобразить сборку, в которой он определен.
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here: => {1}\n", 
                obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // Этот метод позволяет любому целочисленному значению изменить порядок
        // следования десятичных цифр на обратный. Например, для 56 возвратится 65.
        public static int ReverseDigits(this int i)
        {
            // Транслировать int в string и затем получить все его символы.
            char[] didgits = i.ToString().ToCharArray();

            // Изменить порядок следования элементов массива.
            Array.Reverse(didgits);

            // Поместить обратно в строку.
            string newDigits = new string(didgits);

            // Возвратить модифицированную строку как int.
            return int.Parse(newDigits);
        }
    }
}
