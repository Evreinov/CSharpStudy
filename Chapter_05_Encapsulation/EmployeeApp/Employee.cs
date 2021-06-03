using System;

namespace EmployeeApp
{
    partial class Employee
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
                    empName = value; // Лексема value в области set, представляет входное значение,
                                     // присваемое свойству вызывающим кодом и называется
                                     // контекстным ключевым словом.
            }
        }

        // int представляет тип данных, инкапсулируемых этим свойством.
        public int ID // Обратите внимание на отсутствие круглых скобок.
        {
            get { return empID; }
            set { empID = value; }
        }

        public float Pay
        { 
            get { return currPay; } 
            set { currPay = value; } 
        }

        // Свойства сжатые до выражений
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }

        // Свойство, допускающее только чтение.
        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }

        // Методы
        public void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name); // Имя сотрудника.
            Console.WriteLine("Age: {0}", Age); // Имя сотрудника.
            Console.WriteLine("ID: {0}", ID); // Идентификкацтонный номер сотрудника.
            Console.WriteLine("Pay: {0}", Pay); // Текущая выплата.
        }

        // Метод доступа (метод get).
        public string GetName()
        {
            return Name;
        }

        // Метод изменения (метод set).
        public void SetName(string name)
        {
            // Перед присваиванием проверить входное значение.
            if (name.Length > 15)
                Console.WriteLine("Error! Name length exceeds 15 characters!"); // Ошибка! Длина имени превышает 15 символов!
            else
                Name = name;
        }
    }
}
