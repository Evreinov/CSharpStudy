using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int Add(int x, int y)
        {
            // Выполнить здесь проверку достоверности
            return x + y;
        }

        // Лакальная функция в методу AddWrapper
        static int AddWrapper(int x, int y)
        {
            // Выполнить здесь проверку достоверности
            return Add();
            int Add()
            {
                return x + y;
            }
        }
    }
}
