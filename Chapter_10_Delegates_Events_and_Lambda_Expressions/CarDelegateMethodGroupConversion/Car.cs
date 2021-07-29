using System;

namespace CarDelegateMethodGroupConversion
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

        // Шаг 1. Определить тип делегата.
        public delegate void CarEngineHandler(string msgForCaller);
        // Шаг 2. Определить переменную-член этого типа делегата.
        private CarEngineHandler listOfHandlers;
        // Шаг 3. Добавить регистрационную функцию для вызывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            // listOfHandlers = methodToCall;

            // Добавление поддержки группового вызова.
            // Обратите внимание на использование операции +=,
            // а не обычной операции присваивания (=).
            // Когда операция += используется с объектом делегата,
            // компилятор преобразует её в вызов статического метода
            // Delegate.Combine().
            //listOfHandlers += methodToCall;

            // Delegate.Combine() вместо +=.
            if (listOfHandlers == null)
                listOfHandlers = methodToCall;
            else
                listOfHandlers = (CarEngineHandler)Delegate.Combine(listOfHandlers, methodToCall);
        }
        // Шаг 4. Реализовать метод Accelerate() для обращения к списку
        // вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то отправить сообщение об этом.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        /// <summary>
        /// Удаление целей из списка вызовов делегата.
        /// </summary>
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
    }
}
