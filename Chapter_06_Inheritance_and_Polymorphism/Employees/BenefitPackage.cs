namespace Employees
{
    // Этот новый класс будет функционировать как включаемый класс.
    class BenefitPackage
    {
        // Предположим, что есть другие члены, представляющие
        // медицинские/стоматологические программы и т.д.
        public double ComputePayDeduction()
        {
            return 125.0;
        }
    }
}