using System;

namespace Employees
{
    // Превращение класса Employee в абстактный для
    // предотвращения прямого создания его экземпляров.
    abstract partial class Employee
    {
        // Свойства.
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                else
                    empName = value;
            }
        }
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        { 
            get { return currPay; } 
            set { currPay = value; } 
        }
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }
        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }
        // Открываем доступ к объекту через специальное свойство.
        public BenefitPackage Benefits
        {
            get => empBenefits;
            set => empBenefits = value;
        }

        // Методы
        // virtual - может быть (но не обязательно) данный метод может быть переопределен в производном классе.
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }
        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name); // Имя сотрудника.
            Console.WriteLine("Age: {0}", Age); // Имя сотрудника.
            Console.WriteLine("ID: {0}", ID); // Идентификкацтонный номер сотрудника.
            Console.WriteLine("Pay: {0}", Pay); // Текущая выплата.
            Console.WriteLine("SSN: {0}", SocialSecurityNumber);
        }
        // Открываем доступ к некоторому поведению, связанному со льготами.
        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }
    }
}
