namespace Employees
{
    // Продавцам нужно знать количество продаж.
    class SalesPerson : Employee
    {
        public SalesPerson() { }
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales) :
            base(fullName, age, empID, currPay, ssn)
        {
            // Это свойство определено в классе SalesPerson.
            SalesNumber = numbOfSales;
        }
        public int SalesNumber { get; set; }

        // Переопределенный метод.
        // бонус продавца зависит от количества продаж.
        public override sealed void GiveBonus(float amount) // sealed - запечатанный метод, дочерний класс не может его переопределить.
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20; 
            }
            base.GiveBonus(amount * salesBonus);
        }

    }
}