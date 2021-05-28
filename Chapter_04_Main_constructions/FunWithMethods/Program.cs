using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Methods *****\n");
            // Передать две переменные по значению.
            int x = 9, y = 10;
            Console.WriteLine("Before call: X: {0}, Y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", Add(x, y));
            Console.WriteLine("After call: X: {0}, Y: {1}", x, y);
            Console.ReadLine();

            // Присваивать начальные значения локальным переменным, используемым
            // как выходные параметры, не обязательно при условии, что они
            // впервые используются впервые в таком качестве.
            // Версия C# 7 позволяет объявлять параметры out в вызове метода.
            //Add(90, 90, out int ans);
            int ans;
            Add(90, 90, out ans);
            Console.WriteLine("90 + 90 = {0}", ans);
            Console.ReadLine();

            // Множество выходных параметров
            int i; string str; bool b;
            FillTheseValues(out i, out str, out b);
            Console.WriteLine("Int is: {0}", i);
            Console.WriteLine("String is: {0}", str);
            Console.WriteLine("Boolean is: {0}", b);
            Console.ReadLine();

            // Если значение параметра out не интересует, тогда в качестве
            // заполнителя можно использовать отбрасывание. Например, когда
            // нужно выяснить, имеет ли строка допустимый формат даты, но
            // сама разобранная дата не требуется, можно было бы написать такой код
            //if (DateTime.TryParse(dateString, out _))
            //{
            //    // Делать что-то
            //}

            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine("Before: {0}, {1} ", str1, str2);
            SwapStrings(ref str1, ref str2);
            Console.WriteLine("After: {0}, {1} ", str1, str2);
            Console.ReadLine();

            #region Ref locals and params
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Simple Return");
            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            var output = SimpleReturn(stringArray, pos);
            output = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            Console.ReadLine();
            #endregion

            #region Ссылочные локальные переменные и возвращаемые ссылочные значения
            Console.WriteLine("=> Use Ref Return");
            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            ref var refOutput = ref SimpleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            Console.ReadLine();
            // Несколько правил с возвращением ссылочного значения:
            // 1. Результаты стандартного метода не могут присваиваться локальной переменной ref.
            //    Метод должен быть создан как возвращающий ссылочное значение
            // 2. Локальную переменную внутри метода ref нельзя возвращать как локальную переменную ref.
            //    Следующий код работать не будет:
            //ThisWillNotWork(string[] array)
            //{
            //    int foo = 5;
            //    return ref foo;
            //}
            // 3. Не работает с асинхронными методами.
            #endregion

            // Передать список значений double, разделенный запятыми...
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);

            // ... или передать массив значений double.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is: {0} ", average);

            // Среднее из 0 равно 0!
            Console.WriteLine("Average of data is: {0} ", CalculateAverage());
            Console.ReadLine();

            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.ReadLine();

            DisplayFancyMessage(message: "Wow! Very Fancy indeed!", 
                textColor: ConsoleColor.DarkRed, 
                backgroundColor: ConsoleColor.White);

            DisplayFancyMessage(backgroundColor: ConsoleColor.Green,
                message: "Testing...",
                textColor: ConsoleColor.DarkBlue);
            Console.ReadLine();

            // Здесь все впорядке, т.к. позиционные аргументы находятся перед именованными.
            //DisplayFancyMessage(ConsoleColor.Blue,
            //    message: "Testing...",
            //    backgroundColor: ConsoleColor.White);

            // Ошибка в вызове, поскольку позиционные аргументы идут после именованных.
            //DisplayFancyMessage(message: "Testing...",
            //    backgroundColor: ConsoleColor.White,
            //    ConsoleColor.Blue);

            DisplayFancyMessage2(message: "Hello!");
            DisplayFancyMessage2(backgroundColor: ConsoleColor.Green);
        }

        // По умолчанию аргументы передаются по значению
        // (в функцию передаётся копия данных, если данные относятся к категории типов значений)
        static int Add(int x, int y)
        {
            int ans = x + y;
            // Вызывающий код не увидит эти изменения,
            // т.к. модифицируется копия исходных данных
            x = 10000;
            y = 88888;
            return ans;
        }

        // Значения выходных параметров должны быть установлены
        // внутри вызываемого метода.
        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        // Возвращение множества выходных параметров.
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string";
            c = true;
        }

        // Ошибка на этапе компиляции
        //static void ThisWontCompile(out int a)
        //{
        //    Console.WriteLine("Error! Forgat to assing output arg!"); // Ошибка! Забыли присовить значение выходному параметру.
        //}

        // Сылочные параметры.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        // Возвращает значение по позиции в массиве.
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        // Возвращает ссылку на позицию в массиве.
        public static ref string SimpleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }

        // Возвращение среднего из некоторого количества значений double.
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
            // Во избежание любой неоднозначности язык C# требует, чтобы метод поддерживал
            // только один параметр params, который должен быть последним в списке параметров.
        }

        // Необязательные параметры
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
            // Во избежании неоднозначности необязательные параметры должны всегда помещаться в конец сигнатуры метода.
            // Если необязательные параметры обнаруживаются перед обязательными, тогда компилятор сообщит об ошибке.
        }
        // Ошибка! Стандартное значение для необязательного
        // аргумента должно быть известно на этапе компиляции!
        //static void EnterLogData(string message, string owner = "Programmer", DateTime timeStamp = DateTime.Now)
        //{
        //    Console.Beep();
        //    Console.WriteLine("Error: {0}", message);
        //    Console.WriteLine("Owner of Error: {0}", owner);
        //    Console.WriteLine("Time of Error: {0}", timeStamp);
        //}

        // Вызов методов с использованием именованных параметров.
        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;

            // Установить новые цвета и вывести сообщение.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            // Восстановить предыдущие цвета.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;
        }

        // Метод переписан с целью поддержки необязательных аргументов.
        static void DisplayFancyMessage2(ConsoleColor textColor = ConsoleColor.Blue, 
            ConsoleColor backgroundColor = ConsoleColor.White, 
            string message = "Test Message")
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;

            // Установить новые цвета и вывести сообщение.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            // Восстановить предыдущие цвета.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;
        }
    }
}
