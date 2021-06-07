using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {
        // В класс Employee вложени класс BenefitPackage.
        public class BenefitPackage
        {
            // В класс BanefitPackage вложено перечисление BenefitPackageLevel.
            public enum BenefitPackageLevel
            {
                Standart, Gold, Platinum
            }

            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }

        // Поля данных.
        // protected - производные классы теперь могут иметь прямой доступ к этой информации.
        protected string empName;
        protected int empAge;
        protected int empID;
        protected float currPay;
        protected string empSSN;
        // Реализация модели включения/делегации (агрегация).
        protected BenefitPackage empBenefits = new BenefitPackage();

        // Конструкторы
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay, string.Empty) { }
        public Employee(string name, int age, int id, float pay, string ssn)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
            empSSN = ssn;
        }
    }
}
