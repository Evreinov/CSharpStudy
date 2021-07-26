using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithNongenericCollections
{
    class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();

        // Приведение для вызывающего кода.
        public Person GetPerson(int pos) => (Person)arPeople[pos];

        // Вставка только объектов Person.
        public void AddPerson(Person p)
        {
            arPeople.Add(p);
        }

        public void ClearPeople()
        {
            arPeople.Clear();
        }

        public int Count => arPeople.Count;

        // Поддержка перечисления с помощью foreach.
        public IEnumerator GetEnumerator() => arPeople.GetEnumerator();
    }
}
