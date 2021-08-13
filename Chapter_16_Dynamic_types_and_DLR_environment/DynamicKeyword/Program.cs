using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            // Переменая a имеет тип List<int>.
            var a = new List<int> {90};
            // Этот оператор приведет к ошибке на этапе компиляции!
            //a = "Hello";
            PrintThreeStrings();
            Console.WriteLine();
            ChangeDynamicDataType();
            Console.WriteLine();
            InvokeMembersOnDynamicData1();
            Console.ReadLine();
        }

        static void UseObjectVariable()
        {
            // Пусть имеется класс по имени Person.
            object o = new Person() { FirstName = "Mike", LastName = "Larson" };

            // Для получения доступа к свойствам Person
            // Переменную o потребуется перевести к Person.
            Console.WriteLine("Person's first name is {0}", ((Person)o).FirstName);
        }

        static void PrintThreeStrings()
        {
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
        }

        static void ChangeDynamicDataType()
        {
            // Объявить одиночный динамический элемент данных по имени t.
            dynamic t = "Hello!";
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());
        }

        /// <summary>
        /// Вызов членов на динамически объявленных данных.
        /// </summary>
        static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "Hello";
            Console.WriteLine(textData1.ToUpper());

            // Здесь можно было ожидать ошибки на этапе компиляции!
            // Однако все компилируется нормально.
            // Но вовремя выполнения будет ошибка.
            Console.WriteLine(textData1.toupper());
            Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
        }

        /// <summary>
        /// Вызов членов на динамически объявленных данных c обработкой ошибок.
        /// </summary>
        static void InvokeMembersOnDynamicData1()
        {
            dynamic textData1 = "Hello";
            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toupper());
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    /// <summary>
    /// Область применения ключевого слова dynamic.
    /// </summary>
    class VeryyDynamicClass
    {
        // Динамическое поле.
        private static dynamic myDynamicField;

        // Динамическое свойство.
        public dynamic DynamicProperty { get; set; }

        // Динамический тип возврата и динамический тип параметра.
        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            // Динамическая локальная переменная.
            dynamic dynamicLocalVar = "Local variable";
            int myInt = 10;
            if (dynamicParam is int)
            {
                return dynamicLocalVar;
            }
            else
            {
                return myInt;
            }
        }

        void LambdaMethod()
        {
            dynamic a = GetDynamicObject();
            // Ошибка! Методы на динамические данные не могут использовать лямбда-выражения!
            //a.Method(ArgIterator => Console.WriteLine(arg));

            // Ошибка! Выражения запросов с dynamic запрещены.
            //var data = from d in a select d;
        }

        dynamic GetDynamicObject() { return 0; }
    }
}
