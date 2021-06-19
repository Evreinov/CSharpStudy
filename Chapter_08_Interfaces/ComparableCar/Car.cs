using System;
using System.Collections;

namespace ComparableCar
{
    class Car : IComparable
    {
        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        public int CarID { get; set; }
        // Свойство, возвращающее PetNameComparer.
        public static IComparer SortByPetName
        {
            get { return (IComparer)new PetNameComparer(); }
        }

        // Конструкторы
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }

        //int IComparable.CompareTo(object obj)
        //{
        //    Car temp = obj as Car;
        //    if (temp != null)
        //    {
        //        if (this.CarID > temp.CarID)
        //            return 1;
        //        if (this.CarID < temp.CarID)
        //            return -1;
        //        else
        //            return 0;
        //    }
        //    else
        //        throw new ArgumentException("Parameter is not a Car!"); // Параметр не является объектом типа Car!
        //}

        // Т.к. System.Int32 реализует интерфей IComparable,
        // реализацию млэно упростить.
        int IComparable.CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
                return this.CarID.CompareTo(temp.CarID);
            else
                throw new ArgumentException("Parameter is not a Car!"); // Параметр не является объектом типа Car!
        }
    }

}
