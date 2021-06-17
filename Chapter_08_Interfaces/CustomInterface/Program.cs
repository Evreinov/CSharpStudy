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
            Console.WriteLine();
            #endregion

            #region Получение ссылок на интерфейсы: ключевое слово is
            // Создать массив элементов Shape.
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            // Получить первый элемент, имеющий вершины.
            // В целях безопасности не помешает проверить firstPointyItem на равенство null.
            IPointy firstPointyItem = FindFirstPointyShape(myShapes);
            Console.WriteLine("The item has {0} points", firstPointyItem.Points);
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
                // Можно ли нарисовать эту фигуру в трехмерном ввиде?
                if (myShapes[i] is IDraw3D)
                    DrawIn3D((IDraw3D)myShapes[i]);
                Console.WriteLine();
            }
            #endregion

            #endregion

            Console.ReadLine();
        }

        // Использование интерфейсов в качестве параметров
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        // Использование интерфейсов в качестве возвращаемых значений
        // Этот метод возвращает первый объект в массиве,
        // который реализует интерфейс IPointy.
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape shape in shapes)
            {
                if (shape is IPointy ip)
                    return ip;
            }
            return null;
        }
    }
}
