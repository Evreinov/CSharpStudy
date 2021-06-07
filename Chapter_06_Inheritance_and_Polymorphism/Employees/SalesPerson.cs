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
        
    }
}