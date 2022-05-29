using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithCSharpAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(" Fun With Async ===>");

            List<int> l = default;
            Console.WriteLine(DoWork());
            Console.WriteLine("Completed");

            string message = await DoWorkAsync();
            Console.WriteLine(message);

            // Вызов асинхронного метода возвращающего void
            await MethodReturningVoidAsync();
            Console.WriteLine("Void method complete");

            // Вызов асинхронных методов с множеством контекстов await.
            await MultiAwaits();
            Console.WriteLine("MultiAwaits complete");

            // Вызов асинхронных методов из неасинхронных методов.
            Console.WriteLine(DoWorkAsync().Result);

            // остановить выполнение до тех пор, пока не произойдет возврат из метода.
            MethodReturningVoidAsync().Wait();

            await MethodWithProblems(10, -23);
            Console.WriteLine("MethodWithProblemComplete");
            MethodWithProblemsFixed(10, -3);

            Console.ReadLine();
        }

        // Синхроный метод.
        private static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work!";
        }

        // Асинхронный метод.
        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5_000);
                return "Done with work!";
            });
        }

        // Асинхронный метод возвращающий void.
        static async Task MethodReturningVoidAsync()
        {
            await Task.Run(() =>
            {
                /* Выполнить какую-то работу... */
                Thread.Sleep(4_000);
            });
            Console.WriteLine("Void method completed");
        }

        // Асинхронный метод с множеством контекстов await.
        static async Task MultiAwaits()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with first task!");
            });
            await Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with second task!");
            });
            await Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with third task!");
            });
        }

        // Ожидание с помощью await в блоках catch и finally.
        static async Task<string> MethodWithTryCatch()
        {
            try
            {
                // Выполнить некоторую работу.
                return "Hello";
            }
            catch (Exception ex)
            {
                //await LogTheErroes();
                throw;
            }
            finally
            {
                //await DoMagicCleanUp();
            }
        }

        // Обощенные возвращаемые типы в асинхронных методах (нововведение).
        // Необходим NuGet-пакет System.Threading.Task.Extensions.
        static async ValueTask<int> ReturnAnInt()
        {
            await Task.Delay(1_000);
            return 5;
        }

        // Работа с локальными функциями.
        static async Task MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            await Task.Run(() =>
            {
                // Вызвать длительно выполняющийся метод.
                Thread.Sleep(4_000);
                Console.WriteLine("First Complete");
                // Вызвать еще один длительно выполняющийся метод, который терпит
                // неудачу из-за того, что значение второго параметра выходит
                // за пределы допустимого диапазона.
                Console.WriteLine("Something bad happened");
            });
        }

        static async Task MethodWithProblemsFixed(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            if (secondParam < 0)
            {
                Console.WriteLine("Bad data");
                return;
            }

            actualImplementation();

            async Task actualImplementation()
            {
                await Task.Run(() =>
                {
                    // Вызвать длительно выполняющийся метод.
                    Thread.Sleep(4_000);
                    Console.WriteLine("First Complete");
                    // Вызвать еще один длительно выполняющийся метод, который терпит
                    // неудачу из-за того, что значение второго параметра выходит
                    // за пределы допустимого диапазона.
                    Console.WriteLine("Something bad happened");
                });
            }
        }
    }
}
