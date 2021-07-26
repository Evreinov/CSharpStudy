using System;

namespace CustomGenericMethods
{
    /// <summary>
    /// Можно обобщенные методы вынести в отдельный класс, как и обычные методы.
    /// </summary>
    public static class MyGenericMethods
    {
        /// <summary>
        /// Этот метод будет менять местами два элемента
        /// типа, указанного в параметре <T>.
        /// </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Обобщенный метод не принимает, не один параметр.
        /// </summary>
        public static void DisplayBaseClass<T>()
        {
            // BaseType - метод, используемый в рефлексии.
            Console.WriteLine("Base class of {0} is: {1}", typeof(T), typeof(T).BaseType);
        }
    }
}
