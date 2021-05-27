using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with type conversions *****");

            // Добавить две переменные типа short и вывести результат
            // short numb1 = 9, numb2 = 10;
            // Console.WriteLine("{0} + {1} = {2}", numb1, numb2, Add(numb1, numb2));
            
            short numb1 = 30000, numb2 = 30000;

            // Следующий код вызовет ошибку на этапе компиляции
            //short answer = Add(numb1, numb2);

            // Явно привести int к short (и разрешить потерю данных).
            short answer = (short)Add(numb1, numb2);

            Console.WriteLine("{0} + {1} = {2}", numb1, numb2, answer);
            NarrowingAttempt();
            ProcessBytes();
            Console.ReadLine();
        }


        static int Add(int x, int y)
        {
            return x + y;
        }

        // Переполнение без проверки
        //static void ProcessBytes()
        //{
        //    byte b1 = 100;
        //    byte b2 = 250;
        //    byte sum = (byte)Add(b1, b2);

        //    // В sum должно содержаться значение 350. Однако там оказывается значение 94!
        //    Console.WriteLine("sum = {0}", sum);
        //    Console.WriteLine();
        //}

        /// <summary>
        /// Ключевые слова checked и unchecked
        /// </summary>
        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            // На этот раз сообщить компилятору о необходимости добавления
            // кода CIL, необходимого для генерации исключения, если возникает
            // переполнение или потеря значимости.
            try
            {
                //byte sum = checked((byte)Add(b1, b2));
                //Console.WriteLine("sum = {0}", sum);

                // Принудительная проверка для целого блока операторов.
                checked
                {
                    byte sum = (byte)Add(b1, b2);
                    Console.WriteLine("sum = {0}", sum);
                }

                // Предполагая, что флаг /checked активирован, этот блок
                // не будет генерировать исключение времени выполнения.
                // Установка флага => Свойства проекта -> Сборка -> Доплнительно -> Проверять арифметическое переполнение и потерю значимости.
                //unchecked
                //{
                //    byte sum = (byte)Add(b1, b2);
                //    Console.WriteLine("sum = {0}", sum);
                //}

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // В sum должно содержаться значение 350.Однако там оказывается значение 94!
            //byte sum = (byte)Add(b1, b2);
            //Console.WriteLine("sum = {0}", sum);

            Console.WriteLine();
        }

        // Ошибка на этапе компиляции
        //static void NarrowingAttempt()
        //{
        //    byte myByte = 0;
        //    int myInt = 200;
        //    myByte = myInt;
        //    Console.WriteLine("Value of myByte: {0}", myByte);
        //}

        // Явное приведение
        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;
            myByte = (byte)myInt;
            Console.WriteLine("Value of myByte: {0}", myByte);
            Console.WriteLine();
        }
    }
}
