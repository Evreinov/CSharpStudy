using System;

namespace CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");

            // Создать объект Car.
            Car c1 = new Car("SlugBug", 100, 10);

            // Сообщить объекту Car, какой метод вызывать,
            // когда он пожелает отправить сообщение.
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            // Сохранить объект делегата, чтобы позже можно было
            // отменить регистрацию.
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);

            // Увеличить скорость (это инициирует события).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            
            // Отменить регистрацию второго обработчика.
            c1.UnRegisterWithCarEngine(handler2);

            // Сообщения в верхнем регистре больше не выводятся.
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("************************************\n");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }
    }
}
