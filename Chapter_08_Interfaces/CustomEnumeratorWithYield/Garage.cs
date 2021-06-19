using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
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

        // Итераторный метод.
        //public IEnumerator GetEnumerator()
        //{
        //    // Исключение не сгенерируется до тех пор, пока не будет вызван метод MoveNext().
        //    throw new Exception("This won't get called");
        //    foreach (Car c in carArray)
        //    {
        //        yield return c;
        //        // Ключевое слово yield применяется для
        //        // указания значения или значений, которые
        //        // подлежат возвращению конструкцией 
        //        // foreach вызывающему коду.

        //        // При достижении оператора yield return
        //        // текущее местоположение в контейнере сохраняется
        //        // и выполнение возобновится с этого местоположения,
        //        // когда итератор вызывается в следующий раз.
        //    }

        //    // Допускается и так:
        //    yield return carArray[0];
        //    yield return carArray[1];
        //    yield return carArray[2];
        //    yield return carArray[3];
        //}

        public IEnumerator GetEnumerator()
        {
            // Это исключение сгенерируется немедленно.
            throw new Exception("This won't get called");
            return actualImplementatation();

            // Закрытая функция.
            IEnumerator actualImplementatation()
            {
                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        }

        #region Построение именованного итератора.

        public IEnumerable GetTheCars (bool returnReversed)
        {
            // Выполнить проверку на предмет ошибок.
            return actualEmplementation();

            IEnumerable actualEmplementation()
            {
                // Возвратить элементы в обратном порядке.
                if (returnReversed)
                {
                    for (int i = carArray.Length; i != 0; i--)
                    {
                        yield return carArray[i - 1];
                    }
                }
                else
                {
                    // Возвратить элементы в том порядке, в каком они размещены в массиве.
                    foreach (Car c in carArray)
                    {
                        yield return c;
                    }
                }
            }
        }
        #endregion
    }
}
