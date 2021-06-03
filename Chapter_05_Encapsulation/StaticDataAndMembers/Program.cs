using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Data *****\n");

            // Создать объект счета.
            SavingsAcount s1 = new SavingsAcount(50);
            // Вывести текущую процентную ставку.
            Console.WriteLine("Interest Rate is: {0}", SavingsAcount.GetInterestRate());

            SavingsAcount.SetInterestRate(0.08);

            SavingsAcount s2 = new SavingsAcount(100);
            // Вывести текущую процентную ставку.
            Console.WriteLine("Interest Rate is: {0}", SavingsAcount.GetInterestRate());
            // Вывести текущую процентную ставку через свойство.
            Console.WriteLine("Interest Rate is: {0}", SavingsAcount.InterestRate);

            // Создать новый объект; это не 'сбросит' процентную ставку.
            SavingsAcount s3 = new SavingsAcount(10000.75);
            Console.WriteLine("Interest Rate is: {0}", SavingsAcount.GetInterestRate());

            Console.ReadLine();
        }
    }
}
