using System;

namespace LambdaExpressionsMultipleParams
{
    class Program
    {
        public delegate string VerySimpleDelegate();

        static void Main(string[] args)
        {
            #region Лямбда-выражени с несколькими параметрами.
            // Зарегистрировать делегат как лямбда-выражение.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) =>
            {
                Console.WriteLine("Message: {0}, Result {1}", msg, result);
            });
            // Это приведет к выполнению лямбда-выражения.
            m.Add(10, 10);
            Console.ReadLine();
            #endregion

            #region Лямбда-выражение без параметров.
            // Выести на консоль строку "Enjoy your string!".
            VerySimpleDelegate d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
            Console.WriteLine(d());
            Console.ReadLine();
            #endregion
        }
    }
}
