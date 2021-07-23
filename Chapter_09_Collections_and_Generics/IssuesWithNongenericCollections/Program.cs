using System;
using System.Collections;
using System.Collections.Generic;

namespace IssuesWithNongenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleBoxUnboxOperation();
            WorkWithArrayList();
            ArrayListOfRandomObjects();
            UsePersonCollection();
            UseGenericList();

            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Первый взгляд на обобщенные коллекции
        /// </summary>
        static void UseGenericList()
        {
            Console.WriteLine("***** Fun with Generics *****\n");

            // Этот объект List<> может хранить только объекты Person.
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);

            // Этот объект List<> может хранить только целые числа.
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];

            // Ошибка на этапе компиляции! Объект Person
            // не может быть добавлен в список элементов int!
            //moreInts.Add(new Person());
            
        }

        /// <summary>
        /// Пример решения проблемы с безопасностью к типам.
        /// Недостатки:
        /// - создание однотипных классов коллекций.
        /// - не решается проблема по упаковке/распаковке.
        /// </summary>
        static void UsePersonCollection()
        {
            Console.WriteLine("***** Custom Person Collection *****\n");
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Homer", "Simpson", 40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Lisa", "Simpson", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));

            // Это вызовет ошибку на этапе компидяции!
            //myPeople.AddPerson(true);

            foreach (Person p in myPeople)
                Console.WriteLine(p);
        }

        /// <summary>
        /// Илюстрация проблемы безопасности к типам.
        /// </summary>
        static void ArrayListOfRandomObjects()
        {
            // ArrayList может хранить вообще все что угодно.
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);
        }

        /// <summary>
        /// Практический пример упаковки и распаковки.
        /// </summary>
        static void WorkWithArrayList()
        {
            // Типы значений автоматически упаковываются при передачи
            // методу, который требует экземпляр типа object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            // Распаковка происходит, когда объект преобразуется
            // обратно в данные, расположенные в стеке.
            int i = (int)myInts[0];

            // Теперь значение вновь упаковывается, т.к.
            // метод WriteLine() требует типа object!
            Console.WriteLine("Value of your int: {0}", i);
        }

        /// <summary>
        /// Простая упаковка и распаковка.
        /// </summary>
        static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (int).
            int myInt = 25;

            // Упаковать int в ссылку на object.
            object boxedInt = myInt;

            // Распаковать ссылку обратно в int.
            try
            {
                int unboxed = (int)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
