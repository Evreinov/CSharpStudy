using System.Collections;
using System.Collections.Generic;

namespace StringIndexer
{
    class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();

        // Этот индексатор возвращает объект лица на основе строкового индекса.
        public Person this[string name]
        {
            get => (Person)listPeople[name];
            set => listPeople[name] = value;
        }

        // Приведение для вызывающего кода.
        public Person GetPerson(string pos) => (Person)listPeople[pos];

        // Вставка только объектов Person.
        public void AddPerson(Person p)
        {
            listPeople.Add(p.FirstName, p);
        }

        public void ClearPeople()
        {
            listPeople.Clear();
        }

        public int Count => listPeople.Count;

        // Поддержка перечисления с помощью foreach.
        public IEnumerator GetEnumerator() => listPeople.GetEnumerator();
    }
}
