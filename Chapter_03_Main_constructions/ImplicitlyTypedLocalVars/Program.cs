using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main(string[] args)
        {
            DeclareExplicitVars();
            DeclareImplicitVars();
            LinQueryOverInts();
            Console.ReadLine();
        }

        /// <summary>
        /// Понятие явно типизированных локальных переменных.
        /// </summary>
        static void DeclareExplicitVars()
        {
            // Явно типизированные локальные переменные
            // объявляются следующим образом:
            // типДанных имяПеременной = начальноеЗначение;
            int myInt = 0;
            bool myBool = true;
            string myString = "Time, marches on...";

            // Вывести имена лежащих в основе типов.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name); // Вывод типа myInt
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name); // Вывод типа myBool
            Console.WriteLine("myString is a: {0}", myString.GetType().Name); // Вывод типа myString
            Console.WriteLine();
        }

        /// <summary>
        /// Понятие неявно типизированных локальных переменных.
        /// </summary>
        static void DeclareImplicitVars()
        {
            // Неявно типизированные локальные переменные
            // объявляются следующим образом:
            // var имяПеременной = начальноеЗначение;
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            // Вывести имена лежащих в основе типов.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name); // Вывод типа myInt
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name); // Вывод типа myBool
            Console.WriteLine("myString is a: {0}", myString.GetType().Name); // Вывод типа myString
            Console.WriteLine();
        }

        /// <summary>
        /// Неявно типизированные данные являются строго типизированными.
        /// </summary>
        static void ImplicitTypingIsStrongTyping()
        {
            // Компилятору известно, что s имеет тип System.String.
            var s = "This variable can only hold string data!";
            s = "This is fine...";

            // Можно обращаться к любому члену лежащего в основе типа.
            string upper = s.ToUpper();

            // Ошибка! Присваивание числовых данных строке не допускается!
            //s = 44;
        }

        /// <summary>
        /// Полезность неявно типизированных локальных переменных.
        /// </summary>
        static void LinQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Запрос LINQ!
            var subset = from i in numbers where i < 10 select i;
            Console.WriteLine("Values in subset: ");
            foreach (var i in subset)
            {
                Console.WriteLine("{0} ", i);
            }
            Console.WriteLine();

            // К какому же типу относиться subset?
            Console.WriteLine("subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("subset is defined in: {0}", subset.GetType().Namespace);
        }
    }

    /*
    class ThisWillNeverCompile
    {
        // Ошибка! Ключевое слово var не может применяться к полям!
        private var myInt = 10;

        // Ошибка! Ключевое слово var не может применяться
        // к возвращаемому значению или типу параметра
        public var MyMethod(var x, var y) { }

        // Ошибка! Должно быть присвоено значение!
        var myData;
        // Ошибка! Значение должно присваиваться в самом объявлении!
        var myInt;
        myInt = 10;
        // Ошибка! Нельзя присваивать null в качестве начального значения!
        var myObj = null;

        // Допустимо, если SportCar имеет ссылочный тип
        var myCar = new SportsCar();
        myCar = null;

        // Также нормально!
        var myInt = 0;
        var anotherInt = myInt;

        string myString = "Wake up!";
        var myData = myString;

        /// <summary>
        /// Неявно типизированную локальную переменную разрешено возвращать вызывающему 
        /// компоненту при условии, что возвращаемый тип метода и выведенный тип переменной,
        /// определенной посредством var, совпадают.
        /// </summary>
        static int GetAnInt()
        {
            var retVal = 9;
            return retVal;
        }
    }
    */
}
