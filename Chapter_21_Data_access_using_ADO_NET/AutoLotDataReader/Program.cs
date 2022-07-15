using System.Data.SqlClient;
using static System.Console;

namespace AutoLotDataReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with Data readers *****\n");

            // Создать строку подключения с помощью объекта построителя.
            //var cnStringBuilder = new SqlConnectionStringBuilder
            //{
            //    InitialCatalog = "AutoLot",
            //    DataSource = @"(localdb)\mssqllocaldb",
            //    ConnectTimeout = 30,
            //    IntegratedSecurity = true,
            //};

            // В качестве параметра в SqlConnectionStringBuilder может передаваться и connectionString,
            // полученные значения которого можно динамически заменить.

            // Предположим, что значение connectionString на самом деле получено
            // из файла *.config.
            string connectionString = @"Data Source=(localdb)\mssqllocaldb; Integrated Security=True; Initial Catalog = AutoLot";
            SqlConnectionStringBuilder cnStringBuilder = new SqlConnectionStringBuilder(connectionString);
            // Изменить значение таймаута.
            cnStringBuilder.ConnectTimeout = 5;

            // Создать и открыть подключение.
            using (SqlConnection connection = new SqlConnection())
            {
                //connection.ConnectionString =
                //    @"Data Source=(localdb)\mssqllocaldb; Integrated Security=True; Initial Catalog = AutoLot; Connect Timeout = 30";
                connection.ConnectionString = cnStringBuilder.ConnectionString;
                connection.Open();

                ShowConnectionStatus(connection);

                // Создать объект команды SQL.
                string sql = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                // Получить объект чтения данных с помощью ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // Пройти в цикле по результатам.
                    //while (myDataReader.Read())
                    //{
                    //    WriteLine($"-> Make: {myDataReader["Make"]}, PetName: {myDataReader["PetName"]}, Color: {myDataReader["Color"]}.");
                    //}
                    // Пример, как избежать жестко закодированных имен.
                    while (myDataReader.Read())
                    {
                        WriteLine("***** Record *****");
                        for (int i = 0; i < myDataReader.FieldCount; i++)
                        {
                            WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                        }
                    }
                }

                // Пример получения множества результирующих наборов с использованием объекта чтения данных.
                string sql1 = "Select * From Inventory; Select * From Customers";
                SqlCommand myCommand1 = new SqlCommand(sql1, connection);

                using (SqlDataReader myDataReader = myCommand1.ExecuteReader())
                {
                    do
                    {
                        while (myDataReader.Read())
                        {
                            WriteLine("***** Record *****");
                            for (int i = 0; i < myDataReader.FieldCount; i++)
                            {
                                WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                            }
                            WriteLine();
                        }
                    } while (myDataReader.NextResult());
                }
            }

            ReadLine();
        }

        private static void ShowConnectionStatus(SqlConnection connection)
        {
            // Вывести различные сведения о текущем объекте подключения.
            WriteLine("***** Info about your connection *****");
            WriteLine($"DataBase location: {connection.DataSource}"); // Местоположение базы данных.
            WriteLine($"Database bane: {connection.Database}"); // Имя базы данных.
            WriteLine($"Timeout: {connection.ConnectionTimeout}"); // Таймаут.
            WriteLine($"Connection state: {connection.State}\n"); // Состояние.
        }
    }
}
