using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interfaces *****\n");

            #region Обращение к членам интерфейса на уровне объектов.

            // Обратиться к свойству Points, определенному в интерфейсе IPointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine("Points: {0}", hex.Points);

            #region Перехватить возможное исключение InvalidCastException, если объект не поддерживает интерфейс IPointy.
            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region Получение ссылок на интерфейсы: ключевое слово as
            Hexagon hex2 = new Hexagon("Peter");
            // Можно ли hex2 трактовать как IPointy?
            IPointy itfPt2 = hex2 as IPointy;
            if (itfPt2 != null)
                Console.WriteLine("Points: {0}", itfPt2.Points);
            else
                Console.WriteLine("OOPS! Not pointy...");
            #endregion

            #region Получение ссылок на интерфейсы: ключевое слово is
            // Создать массив элементов Shape.
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            for (int i = 0; i < myShapes.Length; i++)
            {
                // Базовый класс Shape определяет абстрактный член Draw(), 
                // поэтому все фигуры знают, как себя рисовать.
                myShapes[i].Draw();
                // У каких фигур есть вершины?
                if (myShapes[i] is IPointy ip)
                    Console.WriteLine("-> Points: {0}", ip.Points); // есть вершины
                else
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName); // нет вершин
                Console.WriteLine();
            }
            #endregion 

            #endregion

            Console.ReadLine();
        }
    }
}
