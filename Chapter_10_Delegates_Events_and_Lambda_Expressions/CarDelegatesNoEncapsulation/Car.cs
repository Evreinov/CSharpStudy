namespace CarDelegatesNoEncapsulation
{
    class Car
    {
        // Данные состояния.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        // Исправлен ли автомобиль?
        private bool carIsDead;

        // Конструкторы класса.
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public delegate void CarEngineHandler(string msgForCaller);
        // Теперь этот класс public!
        public CarEngineHandler listOfHandlers;

        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то отправить сообщение об этом.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            }
        }
    }
}
