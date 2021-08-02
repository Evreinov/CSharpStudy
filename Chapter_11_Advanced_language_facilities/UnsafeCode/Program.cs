using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Знакомство с небезопасным кодом.
            unsafe
            {
                // Здесь работаем с указателями.
                int myInt = 10;
                // Нормально, мы находимся в небезопасном контексте.
                SquareIntPointer(&myInt);
                Console.WriteLine("myInt: {0}", myInt);
                Console.WriteLine();

                PrintValueAndAddress();
            }
            // Здесь работа с указателями невозможна!
            //int myInt = 10;
            // Ошибка на этапе компиляции! Это должно делаться в небезопасном контексте!
            //SquareIntPointer(&myInt);
            //Console.WriteLine("myInt: {0}", myInt);
            Console.ReadLine();
            Console.Clear();
            #endregion

            Console.WriteLine("***** Calling method with unsafe code *****\n");

            // Значения, подлежащие обмену.
            int i = 10, j = 20;

            // "Безопасный" обмен значений.
            Console.WriteLine("\n***** Safe swap *****");
            Console.WriteLine("Values before safe swap: i = {0}, j = {1}", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

            // "Небезопасный" обмен значений.
            Console.WriteLine("\n***** Unsafe swap *****");
            Console.WriteLine("Values before unsafe swap: i = {0}, j = {1}", i, j);
            unsafe
            {
                UnsafeSwap(&i, &j);
            }
            Console.WriteLine("Values after unsafe swap: i = {0}, j = {1}", i, j);

            Console.ReadLine();
            Console.Clear();

            UsePointerToPoint();
            Console.ReadLine();
            Console.Clear();

            UseSizeOfOperator();
            UseSizeOfOperator2();
            Console.ReadLine();
            Console.Clear();

        }

        static unsafe void SquareIntPointer(int* myIntPointer)
        {
            // Возвести значение в квадрат просто для тестирования.
            *myIntPointer *= *myIntPointer;
        }

        /// <summary>
        /// Работа с операциями * и &.
        /// </summary>
        static unsafe void PrintValueAndAddress()
        {
            int myInt;

            // Определить указатель на int и присвоить ему фдрес myInt.
            int* ptrToMyInt = &myInt;

            // Присвоить значение myInt, используя обращение через указатель.
            *ptrToMyInt = 123;

            // Вывести некоторые значения.
            Console.WriteLine("Value of myInt {0}", myInt); // значение myInt
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt); // адрес myInt
        }

        /// <summary>
        /// Небезопасный обмен значениями.
        /// </summary>
        public unsafe static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        /// <summary>
        /// Безопасный обмен значениями.
        /// </summary>
        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        /// <summary>
        /// Доступ к полям через указатели (операция ->).
        /// </summary>
        static unsafe void UsePointerToPoint()
        {
            // Доступ к членам через указатель.
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            // Доступ к членам через разыменованный указатель.
            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }

        /// <summary>
        /// Ключевое слово stackalloc.
        /// </summary>
        static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
                p[k] = (char)k;
        }

        /// <summary>
        /// Закрепление типа посредством ключевого слова fixed (что бы не удалил сборщик мусора,
        /// когда работаем с объектом из небезопасного кода).
        /// </summary>
        public unsafe static void UseAndPinPoint()
        {
            PointRef pt = new PointRef
            {
                x = 5,
                y = 6
            };

            // Закрепить указатель pt на месте, чтобы он не мог
            // быть перемещен или уничтожен сборщиком мусора.
            fixed (int* p = &pt.x)
            {
                // Использовать здесь переменную int*!
            }
            // Указатель pt теперь не закреплен и готов
            // к сборке мусора после завершения метода.
            Console.WriteLine("Point is: {0}", pt);
        }

        /// <summary>
        /// Ключевое слово sizeof
        /// </summary>
        static void UseSizeOfOperator()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short)); // Размер short
            Console.WriteLine("The size of int is {0}.", sizeof(int)); // Размер int
            Console.WriteLine("The size of long is {0}.", sizeof(long)); // Размер long
        }

        /// <summary>
        /// Ключевое слово sizeof в небезопасном контексте.
        /// </summary>
        static unsafe void UseSizeOfOperator2()
        {
            Console.WriteLine("The size of Point is {0}.", sizeof(Point)); // Размер Point
        }
    }
}
