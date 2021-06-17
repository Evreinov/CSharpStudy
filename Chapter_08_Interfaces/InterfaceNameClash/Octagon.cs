using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // Ошибка бизнес логики!
        // Неявная реализация, один метод воспринимается компилятором,
        // как реализация для всех интерфейсов
        //public void Draw()
        //{
        //    // Разделяемая логика вывода.
        //    Console.WriteLine("Drawing the Octagon...");
        //}

        // Явно привязать реализации Draw() к конкретным интерфейсам.
        // Явно реализованные члены, автоматически закрыты
        // (для обращения к ним, необходимо объект класса привести к интерфейсу)
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form..."); // Вывод на форму
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to memory..."); // Вывод в память
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to printer..."); // Вывод на принтер
        }
    }
}
