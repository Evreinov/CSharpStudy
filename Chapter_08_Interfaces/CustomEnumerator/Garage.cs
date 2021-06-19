using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    // Garage содержит набор объектов Car.
    class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];

        // При запуске заполнить несколькими объектами Car.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        public IEnumerator GetEnumerator()
        {
            // System.Array уже реализует IEnumerator!
            // Возвратить IEnumerator объекта массива.
            return carArray.GetEnumerator();

        }

        // Скрыть функциональность IEnumerable,
        // пользовательский код не сможет работать с IEnumerator вручную
        // (Например: 
        //  IEnumerator i = carLot.GetEnumerator();
        //  i.MoveNext();
        // )
        // при этом констукция foreach при необходимости будет получать интерфейс в фоновом режиме.
        IEnumerator IEnumerable.GetEnumerator()
        {
            // System.Array уже реализует IEnumerator!
            // Возвратить IEnumerator объекта массива.
            return carArray.GetEnumerator();
        }
    }
}
