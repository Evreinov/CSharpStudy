using System;

namespace CarEventsWithLambdas
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

        #region Понятие событий
        //// Шаг 1. Определить тип делегата.
        ////public delegate void CarEngineHandler(string msgForCaller);
        //public delegate void CarEngineHandler(object sender, CarEventArgs e);
        //// Шаг 2. Объявить события.
        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler AboutToBlow;
        //// Шаг 3. Реализовать метод Accelerate() для обращения к списку
        //// вызовов делегата в подходящих обстоятельствах. 
        #endregion

        // Событие с помощью обобщенного делегата EventHandler<T>
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то инициализировать событие Exploded.
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    // Обращение к событию с использование null-условной операции.
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }
                // Все ещё в порядке!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
