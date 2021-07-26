using System;
using System.Collections.ObjectModel;

namespace FunWithObservableCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сделать коллекцию наблюдаемой и добавить в нее несколько объектов Person.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };

            // Привязаться к событию CollectionChanged.
            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person { FirstName = "Fred", LastName = "Smith", Age = 32 });
            Console.WriteLine();
            people.Remove(people[0]);

            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Реализация обработчика событий, который будет обходить старый и новый наборы, 
        /// когда элемент вставляется или удаляется из имеющейся коллекции.
        /// </summary>
        /// <param name="sender">Объект, который инициализировал событие.</param>
        /// <param name="e">Предоставляет данные, что вызвало данное событие.</param>
        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Выяснить действие, которое привело к генерации события.
            Console.WriteLine("Action for this event: {0}", e.Action);

            // Было что-то удалено.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:"); // старые элементы
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }

            // Было что-то добавлено.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Теперь вывести новые элементы, которые были вставлены.
                Console.WriteLine("Here are the NEW items:"); // новые элементы
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }
}
