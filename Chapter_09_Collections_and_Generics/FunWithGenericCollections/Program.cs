using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            UseGenericList();
            Console.WriteLine();

            Console.ReadLine();
        }

        /// <summary>
        /// Работа с классом List<T>.
        /// </summary>
        static void UseGenericList()
        {
            // Создать список объектов Person и заполнить его с помощью
            // синтаксиса инициализации объектов и коллекции.
            List<Person> people = new List<Person>()
            {
                new Person {FirstName = "Homer", LastName = "Simpson", Age = 47},
                new Person {FirstName = "Marge", LastName = "Simpson", Age = 45},
                new Person {FirstName = "Lisa", LastName = "Simpson", Age = 9},
                new Person {FirstName = "Bart", LastName = "Simpson", Age = 8},
            };
            // Вывести количество элементов в списке.
            Console.WriteLine("Items in list: {0}", people.Count);
            // Выполнить перечисление по списку.
            foreach (Person p in people)
                Console.WriteLine(p);
            // Вставить новый объект Person.
            Console.WriteLine("\n->Inserting new person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Item in list: {0}", people.Count);
            // Скопировать данные в новый массив.
            Person[] arrayOfPeople = people.ToArray();
            foreach (Person p in arrayOfPeople)
            {
                Console.WriteLine("First Names: {0}", p.FirstName);
            }
        }
    }
}
