using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithTuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Присваивание кортежа переменной.
            (string, int, string) values = ("a", 5, "c");
            //var values = ("a", 5, "c");
            // К каждому значению кортежа присваивается свойство с именем ItemX,
            // где X представляет позицию свойства в кортеже.
            Console.WriteLine($"First item: {values.Item1}");
            Console.WriteLine($"Second item: {values.Item2}");
            Console.WriteLine($"Third item: {values.Item3}");
            Console.ReadLine();

            // К каждому свойству кортежа, можно добавить специфическое имя.
            // Если имена присвоены и в левой и в правой части оператора,
            // то быдут использоваться имена слева, а справа будут игнорироваться.
            (string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
            var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            // Обращение по именам полей.
            Console.WriteLine($"First item: {valuesWithNames.FirstLetter}");
            Console.WriteLine($"Second item: {valuesWithNames.TheNumber}");
            Console.WriteLine($"Third item: {valuesWithNames.SecondLetter}");
            // Система обозначений ItemX по-прежднему работает.
            Console.WriteLine($"First item: {valuesWithNames.Item1}");
            Console.WriteLine($"Second item: {valuesWithNames.Item2}");
            Console.WriteLine($"Third item: {valuesWithNames.Item3}");

            // В данных двух примерах Custom1 и Custom2 игнорируются
            //(int, int) example = (Custom1: 5, Custom2: 7);
            //(int Field1, int Field2) exmple = (Custom1: 5, Custom2: 7);
            // Специальные имена полей существуют только на этапе компиляции и не доступны
            // при инспектировании кортежа во время выполнения с использованием рефлексии.
            Console.ReadLine();

            Console.WriteLine("=> Inferrer Tuple Names");
            var foo = new { Prop1 = "first", Prop2 = "second" };
            var bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");
            Console.ReadLine();

            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"String is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}");
            Console.ReadLine();

            // Отбрасывание кортежа (отчество отбрасывается)
            var (first, _, last) = SplitNames("Philip f Japikse");
            Console.WriteLine($"{first}:{last}");
            Console.ReadLine();

            Point p = new Point(7, 5);
            var pointValues = p.Deconstruct();
            Console.WriteLine($"X is: {pointValues.XPos}");
            Console.WriteLine($"Y is: {pointValues.YPos}");
            Console.ReadLine();
        }

        // Возвращение 3-х значений с помощью модификатора параметра out
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        // Возвращение 3-х значений с помощью кортежа
        static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string.", true);
        }

        // Разбор полного имени на отдельные части
        static (string first, string middle, string last) SplitNames(string fullName)
        {
            // Действия необходимые для расщепления полного имени.
            return ("Philip", "F", "Japikse");
        }
    }

    struct Point
    {
        // Поля структуры
        public int X;
        public int Y;

        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Деконструкция кортежа (обычно метод называют Deconstruct())
        // С помощью единственного вызова метода,
        // можно получить индивидуальные значения структуры путем возвращения кортежа.
        public (int XPos, int YPos) Deconstruct() => (X, Y);
    }
}
