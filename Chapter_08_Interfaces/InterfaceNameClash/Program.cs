using System;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interface Name Clashes *****\n");
            // Все эти обращения приводят к вызову одного и того же метода Draw()!
            Octagon oct = new Octagon();
            
            // Теперь для доступа к членам Draw() должно использоваться приведение.
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            // Сокращенная форма, если переменная интерфейса не нужна.
            ((IDrawToPrinter)oct).Draw();

            // Можно также использовать ключевое слово is.
            if (oct is IDrawToMemory dtm)
                dtm.Draw();

            Console.ReadLine();
        }
    }
}
