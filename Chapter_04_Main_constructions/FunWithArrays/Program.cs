using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Arrays *****");
            SimpleArrays();
            ArrayInitialization();
            DeclareImplicitArrays();
            ArrayofObjects();
            RectMultidimesionalArray();
            JaggedMultidimensionalArray();
            PassAndReceiveArrays();
            SystemArrayFunctionality();
            Console.ReadLine();
        }

        /// <summary>
        /// Понятие массивов
        /// </summary>
        static void SimpleArrays()
        {
            Console.WriteLine("=> Simple Array Creation.");
            // Создать массив int, содержащий 3 элемента с индексами 0, 1, 2.
            int[] myInts = new int[3];
            // Заполнить массив, если массив объявлен, но не заполнен по каждому индексу,
            // то они получат стандарное значение для типа данных int => 0, bool => false и т.д.
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;
            // Вывести все значения.
            foreach (var i in myInts)
                Console.WriteLine(i);

            // Создать массив string, содеражщий 100 элементов с индексами 0 - 99.
            string[] booksOnDotNet = new string[100];
            Console.WriteLine();
        }

        /// <summary>
        /// Синтаксис инициализации массивов
        /// </summary>
        static void ArrayInitialization()
        {
            Console.WriteLine("=> Array Initialization.");
            // Синтаксис инициализации массива с использованием ключевого слова new.
            string[] stringArray = new string[] { "one", "two", "three" };
            Console.WriteLine("stringArray has {0} elements", stringArray.Length);
            // Синтаксис инициализации массива без использования ключевого слова new.
            bool[] boolArray = { false, false, true };
            Console.WriteLine("boolArray has {0} elements", boolArray.Length);
            // Инициализация массива с применением ключевого слова new и указание размера.
            int[] intArray = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine("intArray has {0} elements", intArray.Length);
            // Несоотвествие размера и количества элементов!
            // int[] intArray = new int[2] { 20, 22, 23, 0 };
            Console.WriteLine();
        }

        /// <summary>
        /// Неявно типизированные локальные массивы
        /// </summary>
        static void DeclareImplicitArrays()
        {
            Console.WriteLine("=> Implicit Array Initialization.");

            // Переменная a на самом деле имеет тип int[]
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a is a: {0}", a.ToString());

            // Переменная b на самом деле имеет тип double[]
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b is a: {0}", b.ToString());

            // Переменная b на самом деле имеет тип double[]
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c is a: {0}", c.ToString());

            // Ошибка! Смешанные типы!
            //var d = new[] { 1, "one", 2, "two", false };

            Console.WriteLine();
        }

        /// <summary>
        /// Определение массива объектов
        /// </summary>
        static void ArrayofObjects()
        {
            Console.WriteLine("=> Array of Objects.");

            // Массив объектов может содержать все что угодно.
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form & Void";
            foreach (object obj in myObjects)
            {
                // Вывести тип и значение каждого элемента в массиве.
                Console.WriteLine("Type: {0}, Value: {1}", obj.GetType(), obj);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Прямоугольный массив
        /// </summary>
        static void RectMultidimesionalArray()
        {
            Console.WriteLine("=> Rectangular multidimensional array.");
            // Прямоугольный многомерный массив.
            int[,] myMatrix;
            myMatrix = new int[3, 4];
            // Заполнить массив
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    myMatrix[i, j] = i * j;
            // Вывести содержимое массива (3 * 4)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(myMatrix[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Зубчатый (или ступенчатый) массив
        /// </summary>
        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");
            // Зубчатый многомерный массив (т.е. массив массивов).
            // Здесь мы имеем массив из 5 разных массивов.
            int[][] myJagArray = new int[5][];
            // Создать зубчатый массив.
            for (int i = 0; i < myJagArray.Length; i++)
                myJagArray[i] = new int[i + 7];
            // Вывести все строки (помните, что каждый элемент имеет стандартное значение 0)
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                    Console.Write(myJagArray[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Использование массивов в качестве аргументов и возвращаемых значений.
        /// </summary>
        static void PassAndReceiveArrays()
        {
            Console.WriteLine("=> Arrays as params and return values.");
            // Передать массив в качестве параметра.
            int[] ages = { 20, 22, 23, 0 };
            PrintArray(ages);
            // Получить массив как возвращаемое значение
            string[] strs = GetStringArray();
            foreach (string s in strs)
                Console.WriteLine(s);
            Console.WriteLine();
        }
        /// <summary>
        /// Принимает входной массив значений int и выводит все его элементы на консоль.
        /// </summary>
        static void PrintArray(int[] myInts)
        {
            for (int i = 0; i < myInts.Length; i++)
                Console.WriteLine("Item {0} is {1}", i, myInts[i]);
        }
        /// <summary>
        /// Заполняет массив значений string и возвращает его вызывающему коду.
        /// </summary>
        static string[] GetStringArray()
        {
            string[] theStrings = { "Hello", "from", "GetStringArray" };
            return theStrings;
        }

        /// <summary>
        /// Базовый класс System.Array
        /// </summary>
        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Working with System.Array.");
            // Инициализировать элементы при запуске.
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sister of Mercy" };

            // Вывести имена в порядке их объявления.
            Console.WriteLine("-> Here is the array");
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Вывести имя.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");

            // Обратить порядок следования элементов...
            Array.Reverse(gothicBands);
            Console.WriteLine("-> The reversed array");
            // ... и вывести их.
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Вывести имя.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");

            // Удалить все элементы кроме первого.
            Console.WriteLine("-> Cleared out all but one...");
            Array.Clear(gothicBands, 1, 2);
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Вывести имя.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");
        }
    }
}
