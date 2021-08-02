using System;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Anonymous Types*****\n");
            EqualityTest();
            Console.WriteLine();

            // Создать анонимный тип, представляющий автомобиль.
            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            // Выполнить рефлексию того, что сгенерировал компилятор.
            ReflectOverAnonymousType(myCar);
            // Вывести на консоль цвет и производителя.
            Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);

            // Теперь вызвать вспомогательный метод для построения
            // анонимного типа с указанием аргументов.
            BuildAnonType("BMW", "Black", 10);
            Console.WriteLine();

            // Создать анонимный тип, состоящий из других анонимных типов.
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = 55 },
                Price = 34.000
            };
            ReflectOverAnonymousType(purchaseItem);

            Console.ReadLine();


        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            // Построить анонимный тип с применением входных параметров.
            var car = new { Make = make, Color = color, Speed = currSp };

            // Обратите внимание, что теперь этот тип можно
            // использовать для получения данных свойств!
            Console.WriteLine("You have a {0} {1} going {2} MPH",
                car.Color, car.Make, car.Speed);

            // Анонимные типы имеют специальные реализации каждого
            // виртуального метода System.Object. Например:
            Console.WriteLine("ToString() == {0}", car.ToString());
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }

        static void EqualityTest()
        {
            // Создать два анонимных класса с идентичными наборами пар "имя-значение".
            var firstCar = new { Color = "Bright Pint", Make = "Saab", CurrentSpeed = 55 };
            var secondCar = new { Color = "Bright Pint", Make = "Saab", CurrentSpeed = 55 };

            // Считаются ли они эквивалентными, когда используется Equals()?
            if (firstCar.Equals(secondCar))
                Console.WriteLine("Same anonymous objext!"); // Тот же самый анонимный объект.
            else
                Console.WriteLine("Not the same anonymous object!"); // Не тот же самый анонимный объект.

            // Можно ли проверить их эквивалентность с помощью операции ==?
            if (firstCar == secondCar)
                Console.WriteLine("Same anonymous objext!"); // Тот же самый анонимный объект.
            else
                Console.WriteLine("Not the same anonymous object!"); // Не тот же самый анонимный объект.

            // Имеют ли эти объекты в основе один и тот же тип?
            if (firstCar.GetType().Name == secondCar.GetType().Name)
                Console.WriteLine("We are both the same type!"); // Оба объекта имеют тот же самый тип.
            else
                Console.WriteLine("We are different types!"); // Объекты относятся к разным типам.

            // Отобразить все детали.
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }
    }
}
