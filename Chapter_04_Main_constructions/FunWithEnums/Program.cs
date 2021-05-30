using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    // Специальное перечисление
    enum EmpType
    {                    // = нумерация по умолчанию
        Manager,         // = 0
        Grunt,           // = 1
        Contractor,      // = 2
        VicePresident    // = 3
    }

    // Начать нумерацию с 102
    //enum EmpType
    //{
    //    Manager = 102,
    //    Grunt,           // = 103
    //    Contractor,      // = 104
    //    VicePresident    // = 105
    //}

    // Значения элементов в перечислении не обязательно должны быть
    // последовательными!
    //enum EmpType
    //{
    //    Manager = 10,
    //    Grunt = 1,
    //    Contractor = 100,
    //    VicePresident = 9
    //}

    // На этот раз для элементов EmpType используется тип byte.
    //enum EmpType : byte
    //{
    //    Manager = 10,
    //    Grunt = 1,
    //    Contractor = 100,
    //    VicePresident = 9
    //}

    // Ошибка на этапе компиляции! Значение 999 слишком велико для типа byte!
    //enum EmpType : byte
    //{
    //    Manager = 10,
    //    Grunt = 1,
    //    Contractor = 100,
    //    VicePresident = 999
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Enums *****");
            // Создать переменную типа EmpType
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            //Вывести тип хранилища для значений перечисления.
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(emp.GetType()));
            // В этом варианте, не требуется объялвть переменную сущности.
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpType)));

            // Возвращение строкового  имени текущего значения перечисления
            Console.WriteLine("emp is a {0}.", emp.ToString());
            // Возвращение значения заданной переменной (привести к лежащему в основе типу хранения).
            Console.WriteLine("{0} = {1}", emp.ToString(), (int)emp);

            EmpType e2 = EmpType.Contractor;

            // Эти типы являются перечислениями из пространства имен System.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.ReadLine();
        }

        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?"); // Не желаете ои взамен фондовые опционы?
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding..."); // Вы должно быть шутите...
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You alredy get enough cash..."); // Вы уже получаете вполне достаточно...
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!"); // Очень хорошо, сэр!
                    break;
            }
        }

        //static void ThisMethodWillNotCompile()
        //{
        //    // Ошибка! SaleManager отсутствует в перечислении EmpType!
        //    EmpType emp = EmpType.SalesManager;

        //    // Ошибка! Не указано имя EmpType перед значением Grunt!
        //    emp = Grunt;
        //}

        // Этот метод выводит детали любого перечисления
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information aboud {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            // Получить все пары "имя-значение" для входного параметра.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Вывести строковое имя и ассоциированное значение,
            // использую флаг формата D.
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }
            Console.WriteLine();
        }
    }
}
