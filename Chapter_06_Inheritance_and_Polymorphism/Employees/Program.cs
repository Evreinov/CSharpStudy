using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        // Создание объекта подкласса и доступ к функциональности базового класса.
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Calss Hierarchy *****\n");
            //SalesPerson fred = new SalesPerson();
            //fred.Age = 31;
            //fred.Name = "Fred";
            //fred.SalesNumber = 50;
            //Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            //double cost = chucky.GetBenefitCost();
            //// Определить уровень льгот.
            //Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel =
            //    Employee.BenefitPackage.BenefitPackageLevel.Platinum;

            // Выдать каждому сотруднику бонус?
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.ReadLine();

            CastingExamples();
            Console.ReadLine();

            // Ошибка! Нельзя создавать экземпляр абстрактного класса!
            //Employee emp = new Employee();

            // Ключевое слово as
            object frank = new Manager();
            // Ошибка! Исключение времени выполнения.
            //Hexagon hex = (Hexagon)frank;
            // Перехват возможной ошибки приведения.
            Hexagon hex;
            try
            {
                hex = (Hexagon)frank;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Использование ключевого слова as для проверки совместимости.
            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = new Manager();
            things[3] = "Last thing";

            foreach (object item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null)
                    Console.WriteLine("Item is not a hexagon");
                else
                {
                    h.Draw();
                }
            }
            Console.ReadLine();

            // Использование ключевого слова is (модифицируем метод GivePromotion()).

        }

        static void CastingExamples()
        {
            // Manager "является" System.Object, поэтому в переменной
            // типа object можно сохранять ссылку на Manager.
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            // Ошибка! GivePromotion(frank);
            //(класс_к_которому_нужно_привести)существующая_ссылка
            GivePromotion((Manager)frank);
            // Manager также "является" Employee.
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);
            // PTSalesPerson "Является" SalesPerson.
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
        }

        static void GivePromotion(Employee emp)
        {
            // Повысить зарплату...
            // Предоставить место на парковке компании...
            Console.WriteLine("{0} was promoted!", emp.Name);

            //if (emp is SalesPerson)
            //{
            //    Console.WriteLine("{0} made {1} sale(s)!", emp.Name, ((SalesPerson)emp).SalesNumber);
            //    Console.WriteLine();
            //}
            //if (emp is Manager)
            //{
            //    Console.WriteLine("{0} had {1} stock options...", emp.Name, ((Manager)emp).StockOptions);
            //    Console.WriteLine();
            //}

            // Оптимизация предыдущего кода, исключение двойного приведения.
            // Если SalesPerson, тогда присвоить переменной s.
            //if (emp is SalesPerson s)
            //{
            //    Console.WriteLine("{0} made {1} sale(s)!", emp.Name, s.SalesNumber);
            //    Console.WriteLine();
            //}
            //// Если Manager, тогда присовить переменной m.
            //if (emp is Manager m)
            //{
            //    Console.WriteLine("{0} had {1} stock options...", emp.Name, m.StockOptions);
            //    Console.WriteLine();
            //}

            // Соспоставление с чем угодно.
            if (emp is var _)
            {
                // Делать что-то.
            }

            // Сопоставление с образцом
            switch (emp)
            {
                case SalesPerson s when s.SalesNumber > 5:
                    Console.WriteLine("{0} made {1} sale(s)!", emp.Name, s.SalesNumber);
                    break;
                case Manager m:
                    Console.WriteLine("{0} had {1} stock options...", emp.Name, m.StockOptions);
                    break;
                // Использование отбрасывания.
                //case Intern _:
                //    // Игнорировать практикантов.
                //    break;
                case null:
                    // Предпринять какое-то действие в случае null.
                    break;
            }
        }
    }
}
