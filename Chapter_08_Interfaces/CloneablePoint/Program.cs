using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Cloning *****\n");

            #region Простое клонирование

            //// Две ссылки на один и тот же объект!
            //Point p1 = new Point(50, 50);
            //Point p2 = p1;
            //p2.X = 0;
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            //Console.WriteLine();

            //// Clone() возвращает простой тип object.
            //// Для получения производного типа требуется явное приведение.
            //// Изменение p4.X не приводит к изменению p3.X.
            //Point p3 = new Point(100, 100);
            //Point p4 = (Point)p3.Clone();
            //p4.X = 0;
            //Console.WriteLine(p3);
            //Console.WriteLine(p4); 

            #endregion

            Console.WriteLine("Cloned p3 and stored new Point in p4");
            Point p3 = new Point(100, 100, "Jane");
            Point p4 = (Point)p3.Clone();

            Console.WriteLine("Before modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);
            p4.desc.PetName = "My new Point";
            p4.X = 9;

            Console.WriteLine("\nChanged p4.desc.petName and p4.X");
            Console.WriteLine("After modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);

            Console.ReadLine();
        }
    }
}
