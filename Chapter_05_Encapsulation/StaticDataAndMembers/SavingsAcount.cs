namespace StaticDataAndMembers
{
    // Простой класс депозитного счета.
    class SavingsAcount
    {
        // Данные уровня экземпляра.
        public double currBalance;

        // Статический элемент данных.
        private static double currInterestRate = 0.04;

        // Статическое свойство
        public static double InterestRate 
        {
            get { return currInterestRate; } 
            set { currInterestRate = value; } 
        }

        // Обратите внимание, что конструктор устанавливает
        // значение статического поля currInterestRate
        public SavingsAcount(double balance)
        {
            // currInterestRate = 0.04; // Это статические данные!
                                     // При создании нового объекта, всегда будет ставка сбрасываться на 0.04.
            currBalance = balance;
        }

        // Статический конструктор!
        static SavingsAcount()
        {
            System.Console.WriteLine("In static ctor!"); // В статическом констукторею
            currInterestRate = 0.04;
        }

        /*
         * Статические конструкторы:
         * 1. В отдельно взятом классе может быть определен только один статический конструктор. 
         *    Другими словами, перегружать статический конструктор нельзя.
         * 2. Статический конструктор не имеет модификатора доступа и не может принимать параметры.
         * 3. Статический конструктор выполняется только один раз вне зависимости 
         *    от количества создаваемых объектов заданного класса.
         * 4. Исполняющая система вызывает статичесикй конструктор , когда создает экземпляр класса 
         *    или перед доступом к первому статическому члену из вызывающего кода.
         * 5. Статический конструктор выполняется перед любым конструктором уровня экземпляра.
         */

        // Статические члены для установки/получения процентной ставки.
        public static void SetInterestRate(double newRate) { currInterestRate = newRate; }
        public static double GetInterestRate() { return currInterestRate; }
    }
}
