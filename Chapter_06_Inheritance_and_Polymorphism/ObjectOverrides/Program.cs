using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");
            // ПРИМЕЧАНИЕ: Эти объекты индентичны и предназначены
            // для тестирования методов Equals() и GetHashCode().
            Person p1 = new Person("Homer", "Simpson", 50);
            Person p2 = new Person("Homer", "Simpson", 50);

            // Получить строковые версии объектов.
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p1.ToString() = {0}", p2.ToString());

            // Протестировать переопределённый метод Equals().
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));

            // Проверить хеш-коды.
            Console.WriteLine("Same hash codes?: {0}", p1.GetHashCode() == p2.GetHashCode());
            Console.WriteLine();

            // Изменить возраст p2 и протестировать снова.
            p2.Age = 45;
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p1.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));
            Console.WriteLine("Same hash codes?: {0}", p1.GetHashCode() == p2.GetHashCode());
            Console.ReadLine();
            StaticMembersOfObject();
            Console.ReadLine();


            // Использовать унаследованные члены System.Object.
            //Console.WriteLine("ToString: {0}", p1.ToString());
            //Console.WriteLine("Hash code: {0}", p1.GetHashCode());
            //Console.WriteLine("Type: {0}", p1.GetType());

            //// Создать другие ссылки на p1.
            //Person p2 = p1;
            //object o = p2;

            //// Указывают ли ссылки на один и тот же объект в памяти?
            //if (o.Equals(p1) && p2.Equals(o))
            //{
            //    Console.WriteLine("Same instance!");
            //}
            //Console.ReadLine();
        }

        static void StaticMembersOfObject()
        {
            // Статические члены System.Object.
            Person p3 = new Person("Sally", "jones", 4);
            Person p4 = new Person("Sally", "jones", 4);
            Console.WriteLine("P3 and P4 have same state: {0}", object.Equals(p3, p4));
            Console.WriteLine("P3 and P4 are pointing to same object: {0}", object.ReferenceEquals(p3, p4));
        }
    }

    class Person 
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; set; } = "";

        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }
        public Person() { }

        public override string ToString() => 
            $"[First Name: {FirstName}; Last Name: {LastName}; Age: {Age}]"; // Стандарт
                                                                             // используемый в .Net для результирущей строки.
                                                                             // Отделение пар "имя-значение" друг от друга двоеточием
                                                                             // и помещение всей строки в квадратные скобки.
        // Вариант 1
        //public override bool Equals(object obj)
        //{
        //    if (obj is Person && obj != null)
        //    {
        //        Person temp;
        //        temp = (Person)obj;
        //        if (temp.FirstName == this.FirstName
        //            && temp.LastName == this.LastName
        //            && temp.Age == this.Age)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}

        // Вариант 2.
        // Так как метод ToString() переопределен и учитывает все поля данных класса вверх по цепочке.
        public override bool Equals(object obj) => obj?.ToString() == ToString();

        public override int GetHashCode()
        {
            // Возвратить хеш-код на основе уникальных строковых данных.
            //return SSN.GetHashCode();

            // Если нет уникальных строковых данных,
            // Возвратить хэш-код на основе значения, возвращаемого методом ToString() для объекта Person.
            return this.ToString().GetHashCode();
        }


    }
}
