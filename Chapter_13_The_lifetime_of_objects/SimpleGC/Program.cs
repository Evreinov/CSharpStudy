using System;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** GC Basics *****");
            Console.WriteLine("***** Fun with System.GC *****");

            // Вывести оценочное количество байтов, выделенных в куче.
            Console.WriteLine("Estimated bytes on heap: {0}",
                GC.GetTotalMemory(false));

            // Значения MaxGeneration начинается с 0, поэтому при выводе добавить 1.
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

            // Создать новый объект Car в управляемой куче.
            // Возвращается ссылка на этот объект (refToMyCar).
            Car refToMyCar = new Car("Zippy", 50);

            // Операция точки (.) используется для обращения к членам
            // объекта с применением ссылочной переменной.
            Console.WriteLine(refToMyCar.ToString());

            // Вывести поколение объекта refToMyCar.
            Console.WriteLine("\nGeneration of refToMyCar is: {0}",
                GC.GetGeneration(refToMyCar));

            // Создать большое колличество объектов в целях тестирования.
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();

            // Выполнить сборку муссора только для объектов поколения 0.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            // Вывести поколение refToMyCar.
            Console.WriteLine("Generation of refToMyCar is {0}:", GC.GetGeneration(refToMyCar));

            // Посмотреть, существует ли ещё tonsOfObjects[9000].
            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsIfObjects[9000] is {0}:",
                    GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObjects[9000] is not longer alive.");

            // Вывести количество проведенных сборок мусора для разных поколений.
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

            //// Принудительно запустить сборку мусора
            //// и ожидать финализацию каждого объекта.
            //GC.Collect();
            //GC.WaitForPendingFinalizers(); // Когда сборка мусора запускается вручную,
            //                               // всегда должен вызывать этот метод.

            //GC.Collect(0); // Исследовать только объекты поколения 0.
            //GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }

        static void MakeACar()
        {
            // Если myCar - единственная ссылка на объект Car, то после
            // завершения этого метода объект Car *может* быть уничтожен.
            Car myCar = new Car();
            myCar = null;
        }
    }
}
