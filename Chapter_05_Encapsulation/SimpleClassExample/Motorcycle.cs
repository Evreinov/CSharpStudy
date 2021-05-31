using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Motorcycle
    {
        public int driverIntensity;

        // Новые члены для представления имени водителя.
        public string name;
        // Поле name будет пустой строкой, т.к. компилятор предполагает, что присваение идет к переменной внутри метода.
        //public void SetDriverName(string name)
        //{
        //    name = name;
        //}
        // Присвоение к полю класса.
        public void SetDriverName(string name)
        {
           // Если поле класса и метода имеют разные названия, то ключевое слово this не обязательно.
           // this.driverName = name;
           this.name = name;
        }

        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeeee Haaaaaeewww!");
            }
        }

        // Вернуть стандартный конструктор, который будет 
        // устанавливать все члены данных в стандартные значения.
        // (т.к. если определен специальный конструктор, то стандартный конструктор
        // молча удаляется из класса и перестает быть доступным, нужно стандартный конструктор явно переопределить)
        public Motorcycle() { }

        // Специальный конструктор.
        public Motorcycle(int intensity)
        {
            driverIntensity = intensity;
        }
    }
}
