using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Car
    {
        // Автоматические свойства! Нет нужды определять поддерживающие поля.
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        // Свойство только для чтения? Допустимо!
        //public int MyReadOnlyProp { get; }
        // Свойство только для записи? Ошибка!
        //public int MyWriteOnlyPro { set; }

        public void DisplayStats()
        {
            Console.WriteLine("Car Name: {0}", PetName);
            Console.WriteLine("Speed: {0}", Speed);
            Console.WriteLine("Color: {0}", Color);
        }
    }
}
