using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    #region Person
    class Person
    {
        public string personName;
        public int personAge;

        // Конструкторы.
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person() { }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }
    }
    #endregion

    /*
    Если ссылочный тип передается по ссылке, тогда вызываемый код может изменять значения данных состояния объекта,
    а также объект, на который указывает ссылка.

    Если ссылочный тип передается по значению, то вызываемый код может изменять значения данных состояния объекта,
    но не объект, на который указывает ссылка.
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Передача ссылочных типов по значению.
            Console.WriteLine("***** Passing Person object by value *****");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("\nBefore by value call, Person is:"); // перед вызовом
            fred.Display();

            SendAPersonByValue(fred);
            Console.WriteLine("\nAfter by value call, Person is:"); // после вызова
            fred.Display();
            Console.ReadLine();

            // Передача ссылочных типов по ссылке.
            Console.WriteLine("***** Passing Person object by reference *****");
            Person mel = new Person("Mel", 23);
            Console.WriteLine("\nBefore by value call, Person is:"); // перед вызовом
            mel.Display();

            SendAPersonByReference(ref mel);
            Console.WriteLine("\nAfter by value call, Person is:"); // после вызова
            mel.Display();
            Console.ReadLine();
        }

        // Передача ссылочного типа по значению
        static void SendAPersonByValue(Person p)
        {
            // Изменить значение возраста в p.
            p.personAge = 99;

            // Увидит ли вызывающий код это изменение?
            p = new Person("Nikki", 99);
        }

        // Передача ссылочного типа по ссылке
        static void SendAPersonByReference(ref Person p)
        {
            // Изменить некоторые денные в p.
            p.personAge = 555;

            //p теперь указывает на новый объект в куче!
            p = new Person("Nikki", 999);
        }
    }
}
