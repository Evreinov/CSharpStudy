using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        // Поля данных.
        private string empName;
        private int empAge;
        private int empID;
        private float currPay;
        private string empSSN;

        // Конструкторы
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay, string.Empty) { }
        public Employee(string name, int age, int id, float pay, string ssn)
        {
            //if (name.Length > 15)
            //    Console.WriteLine("Error! Name length exceeds 15 characters!");
            //else
            //    empName = name;
            //empAge = age;
            //empID = id;
            //currPay = pay;

            // Уже лучше! Используйте свойства для установки данных класса.
            // Это сократит количество дублированных проверок на предмет ошибок.
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
            // Если свойство предназанчено только для чтения, это больше невозможно!
            //SocialSecurityNumber = ssn;
            // Проверить надлежащим образом входной параметр ssn и затем установить значение.
            empSSN = ssn;
        }
    }
}
