using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Handling Multiple Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);

            #region Обработка множественных исключений
            //try
            //{
            //    // Вызвать исключение выхода за пределы диапазона аргумента.
            //    myCar.Accelerate(-10);
            //}
            //catch (CarIsDeadException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //// Этот блок будет перехватывать все остальные исключения
            //// помимо CarIsDeadException и ArgumentOutOfRangeException.
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //} 
            #endregion

            #region Общий оператор catch
            //try
            //{
            //    myCar.Accelerate(90);
            //}
            //catch
            //{
            //    Console.WriteLine("Something bad happened..."); // Произошло что-то плохое...
            //} 
            #endregion

            #region Повторная генерация исключений
            //try
            //{
            //    myCar.Accelerate(90);
            //}
            //catch (CarIsDeadException e)
            //{
            //    // Выполнить частичную обработку этой ошибки и передать отвественность.
            //    throw; // throw без аргумнтов, т.к. здесь не создается новый объект
            //           // исключения, а просто передается исходный объект исключения
            //           // (со всей исходной информацией).
            //} 
            #endregion

            #region Внутренние исключение
            //try
            //{
            //    myCar.Accelerate(90);
            //}
            //catch (CarIsDeadException e)
            //{
            //    try
            //    {
            //        // Попытка открытия файла carErrors.txt, расположенного на диске C:.
            //        FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Open);
            //    }
            //    catch (Exception e2)
            //    {
            //        // Сгенерировать исключение, которое записывает новое
            //        // исключение, а также сообщение из первого исключения.
            //        throw new CarIsDeadException(e.Message, e2);
            //    }
            //}
            #endregion

            #region Блок finally
            //myCar.CrankTunes(true);
            //try
            //{
            //    // Вызвать исключение выхода за пределы диапазона аргумента.
            //    myCar.Accelerate(-10);
            //}
            //catch (CarIsDeadException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    // Этот код будет выполняться всегда независимо
            //    // от того, возникало исклбчение или нет.
            //    myCar.CrankTunes(false);
            //}
            #endregion

            #region Фильтры исключений
            try
            {
                myCar.Accelerate(90);
            }
            // Данный блок catch никогда не будет выполняться в пятницу.
            catch (CarIsDeadException e)
             when (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                // Выводится, только если выражение в конструкции when вычисляется, как true.
                Console.WriteLine("Catching car is dead!");
                Console.WriteLine(e.Message);
            } 
            #endregion


            Console.ReadLine();
        }
    }
}
