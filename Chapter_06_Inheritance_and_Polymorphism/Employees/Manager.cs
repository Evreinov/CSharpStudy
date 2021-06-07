using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
{
    // Менеджерам нужно знать количество их фондовых опционов.
    class Manager : Employee
    {
        public Manager() { }
        // base ссылается на сигнатуру конструктора (подобно синтаксису, используемому для объединения
        // конструкторов одиночного класса в цепочку через ключевое слово this), что всегда указывает
        // производному конструктору на необходимость передачи данных конструктору непосредственного
        // родительского класса.
        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numbOfOpts) :
            base (fullName, age, empID, currPay, ssn)
        {
            // Это свойство определено в классе Manager.
            StockOptions = numbOfOpts;
        }
        public int StockOptions { get; set; }
    }
}