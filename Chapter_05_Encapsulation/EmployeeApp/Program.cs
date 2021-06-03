using System;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Encapsulation *****\n");
            Employee emp = new Employee("Marvin", 456, 30000);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            // Использование методов get/set для взаимодействия 
            // с именем сотрудника, представленного оъектом.
            emp.SetName("Marv");
            Console.WriteLine("Employee is named: {0}", emp.GetName());
            Console.ReadLine();

            // Переустановка и затем получение свойств Name.
            emp.Name = "Marvinus";
            Console.WriteLine("Employee is named: {0}", emp.GetName());
            Console.ReadLine();
        }
    }
}
