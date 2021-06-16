using System;

namespace SimpleException
{
    class Car
    {
        // Константа для представления максимальной скорости.
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        // Не вышел ли автомобиль из строя.
        private bool carIsDead;
        // В автомобиле имеется радиоприемник.
        private Radio theMusicBox = new Radio();

        // Конструкторы
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            // Делегировать запрос внутреннему объекту.
            theMusicBox.TurnOn(state);
        }

        // Проверить, не перегрелся ли автомобиль.
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    // Вывод ошибки с помощью текстового сообщения.
                    //Console.WriteLine("{0} has overheated!", PetName);
                    
                    CurrentSpeed = 0;
                    carIsDead = true;
                    
                    // Использование ключевого слова throw для генерации исключения.
                    //throw new Exception($"{PetName} has overheated!");

                    // Мы хотим обращаться к свойству HelpLink, поэтому необходимо
                    // создать локальную переменную перед генерацией объекта Exception.
                    Exception ex = new Exception($"{PetName} has overheated!");
                    ex.HelpLink = "http://www.CarsRUs.com";

                    // Предоставить специальные данные, касающиеся ошибки.
                    ex.Data.Add("TimeStamp", $"The car exploded at {DateTime.Now}");
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
