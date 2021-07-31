using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    // Индексаторы позволяют обращаться к элементтам в стиле массива.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");
            PersonCollection myPeople = new PersonCollection();
            
            // Добавить объеткы с применением синтаксиса индексатора.
            myPeople[0] = new Person("Homer", "Simpson", 40);
            myPeople[1] = new Person("Marge", "Simpson", 38);
            myPeople[2] = new Person("Lisa", "Simpson", 9);
            myPeople[3] = new Person("Bart", "Simpson", 7);
            myPeople[4] = new Person("Maggie", "Simpson", 2);

            // Получить и отобразить элементы, используя индексатор.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i); // Номер лица.
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName); // Имя и фамилия.
                Console.WriteLine("Age: {0}", myPeople[i].Age); // Возраст.
                Console.WriteLine();
            }

            Console.ReadLine();

            UseGenericListOfPeople();
            Console.ReadLine();
        }

        /// <summary>
        /// Обобщенные типы предлагают такую функциональность в готовом виде.
        /// </summary>
        static void UseGenericListOfPeople()
        {
            List<Person> myPeople = new List<Person>();

            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));

            // Изменить первый объект лица с помощью индексатора.
            myPeople[0] = new Person("Maggie", "Simpson", 2);

            // Получить и отобразить элементы, используя индексатор.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i); // Номер лица.
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName); // Имя и фамилия.
                Console.WriteLine("Age: {0}", myPeople[i].Age); // Возраст.
                Console.WriteLine();
            }
        }
    }
}
