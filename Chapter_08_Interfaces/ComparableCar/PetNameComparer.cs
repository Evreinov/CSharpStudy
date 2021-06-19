using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class PetNameComparer : IComparer
    {
        // Проверить дружественной имя каждого объекта.
        int IComparer.Compare(object o1, object o2)
        {
            Car t1 = o1 as Car;
            Car t2 = o2 as Car;
            if (t1 != null && t2 != null)
                return String.Compare(t1.PetName, t2.PetName);
            else
                throw new ArgumentException("Paremater is not Car"); // Парметр не является объектом типа Car!
        }
    }
}
