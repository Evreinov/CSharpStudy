using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Console;

namespace MyConnectionFactory
{
    // Список возможных поставщиков.
    enum DataProvider
    {
        SqlServer,
        OleDb,
        Odbc,
        None,
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Very Simple Connection Factory *****\n");
            // Прочитать ключ provider.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            // Преобразовать строку в перечисление.
            DataProvider dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                WriteLine("Sorry, no provider exists!"); // Поставщики отсутствуют.
                ReadLine();
                return;
            }

            // Получить конкретное подключение.
            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
            WriteLine($"Your connection is a {myConnection.GetType().Name ?? "unrecognized type"}");
            // Открыть, использовать и закрыть подключение...
            ReadLine();
        }

        // Этот метод возвращает конкретный объект подключения
        // на основе значения перечисления DataProvider.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }
            return connection;
        }
    }
}
