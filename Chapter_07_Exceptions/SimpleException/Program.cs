using System;
using System.Collections;

namespace SimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);

            // Вариант без обработки исключения.
            //for (int i = 0; i < 10; i++)
            //    myCar.Accelerate(10);

            // Разогнаться до скорости, превышающей максимальный
            // предел автомобиля, с целью выдачи исключения.
            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelerate(10);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n*** Error! ***");                                          // ошибка
                // Свойство TargetSite в действительности возвращает объект MethodBase.
                Console.WriteLine("Method: {0}", e.TargetSite);                                 // метод
                Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType);    // класс, определяющий член
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);                 // тип члена.
                Console.WriteLine("Message: {0}", e.Message);                                   // сообщение
                Console.WriteLine("Source: {0}", e.Source);                                     // источник       
                Console.WriteLine("Stack: {0}", e.StackTrace);                                  // стек вызова
                Console.WriteLine("Help Link: {0}", e.HelpLink);                                // URL-адрес
                Console.WriteLine("\n-> Custom Data:");
                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("-> {0}: {1}", de.Key, de.Value);
            }
            // Ошибка была обработана, продолжается выполнение следующего оператора.
            Console.WriteLine("\n***** Out of exception logic *****");
            Console.ReadLine();
        }
    }
}
