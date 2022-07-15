using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Console;

namespace DataProviderFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Fun with Data Provider Factories *****\n");

            // Получить строку подключения и поставщик из файла *.config.
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Получить фабрику поставщиков.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            // Получить объект подключения.
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                }
                WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                // Пример обращения к специфичным членам лежащего в основе поставщика (нужно DbConnection привести к требуемому поставщику).
                var sqlConnection = connection as SqlConnection;
                if (sqlConnection != null)
                {
                    // Вывести информацию об используемой версии SQL Server.
                    WriteLine(sqlConnection.ServerVersion);
                }

                // Создать объект команды.
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                // Вывести данные с помощью объекта чтения данных.
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n***** Current Inventory *****");
                    while (dataReader.Read())
                    {
                        WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                    }
                }
            }

            ReadLine();
        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}"); // Возникла проблема с созданием объекта.
            ReadLine();
        }
    }
}
