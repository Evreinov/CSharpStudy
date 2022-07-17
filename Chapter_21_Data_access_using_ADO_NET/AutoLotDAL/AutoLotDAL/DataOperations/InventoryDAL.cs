using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        #region Конструкторы.

        private readonly string _connectionString;

        public InventoryDAL() : this(
            @"Data Source = (localdb)\mssqllocaldb; Integrated Security = True; Initial Catalog = AutoLot")
        {
        }

        public InventoryDAL(string connectionString) => _connectionString = connectionString;

        #endregion

        #region Открытие и закрытие подключения.

        private SqlConnection _sqlConnection = null;

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection {ConnectionString = _connectionString};
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }

        #endregion

        #region Методы выборки.

        public List<Car> GetAllInventory()
        {
            OpenConnection();

            // Здесь будут хранится записи.
            List<Car> inventory = new List<Car>();

            // Подготовить объект команды.
            string sql = "Select * From Inventory";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int) dataReader["CarId"],
                        Color = (string) dataReader["Color"],
                        Make = (string) dataReader["Make"],
                        PetName = (string) dataReader["PetName"],
                    });
                }

                dataReader.Close();
            }

            return inventory;
        }

        public Car GetCar(int id)
        {
            OpenConnection();
            Car car = null;
            string sql = $"Select * From Inventory where CarId = {id}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    car = new Car
                    {
                        CarId = (int) dataReader["CarId"],
                        Color = (string) dataReader["Color"],
                        Make = (string) dataReader["Make"],
                        PetName = (string) dataReader["PetName"],
                    };
                }

                dataReader.Close();
            }

            return car;
        }

        #endregion

        #region Вставка новой записи об автомобиле.

        public void InsertAuto(string color, string make, string petName)
        {
            OpenConnection();
            // Сформировать и выполнить оператор SQL.
            string sql = $"Insert Into Inventory (Make, Color, PetName) Values ('{make}', '{color}', '{petName}')";
            // Выполнить, используя наше подключение.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        // Создание строго типизированного метода вставки записи об автомобиле.
        //public void InsertAuto(Car car)
        //{
        //    OpenConnection();
        //    // Сформировать и выполнить оператор SQL.
        //    string sql =
        //        $"Insert Into Inventory (Make, Color, PetName) Values ('{car.Make}', '{car.Color}', '{car.PetName}')";
        //    // Выполнить, используя наше подключение.
        //    using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
        //    {
        //        command.CommandType = CommandType.Text;
        //        command.ExecuteNonQuery();
        //    }

        //    CloseConnection();
        //}

        // Работа с параметризированными объектами команд.
        public void InsertAuto(Car car)
        {
            OpenConnection();
            // Используются "заполнители" в запросе SQL.
            string sql = "Insert Into Inventory (Make, Color, PetName) Values (@Make, @Color, @PetName)";

            // Эта команда будет иметь внутренние параметры.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                // Заполнить коллекцию параметров.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = car.Make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                CloseConnection();
            }
        }

        #endregion

        #region Добавление логики удаления.

        public void DeleteCar(int id)
        {
            OpenConnection();
            // Получить идентификатор автомобиля, подлежащего удалению,
            // и удалить запись о нем.
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex); // Этот автомобиль заказан! 
                    throw error;
                }
            }
            CloseConnection();
        }

        #endregion

        #region Добавление логики обновления.

        public void UpdateCarPetName(int id, string newPetName)
        {
            OpenConnection();
            // Получить идентификатор автомобиля для модификации дружественного имени.
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        #endregion

        #region Вызов хранимой процедуры.

        public string LookUpPetName(int carId)
        {
            OpenConnection();
            string carPetName;

            // Установить имя хранимой процедуры.
            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Входной параметр.
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(param);

                // Выходной параметр.
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(param);

                // Выполнить хранимую процедуру.
                command.ExecuteNonQuery();

                // Возвратить выходной параметр.
                carPetName = (string)command.Parameters["@petName"].Value;
                CloseConnection();
            }
            return carPetName;
        }

        #endregion

        #region Метод транзакции

        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            OpenConnection();
            // Первым делом найти текущее имя по идентификатору клиента.
            string fName;
            string lName;
            var cmdSelect = new SqlCommand($"Select * from Customers where CustId = {custId}", _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }

            // Создать объекты команд, которые представляют каждый шаг операции.
            var cmdRemove = new SqlCommand($"Delete from Customers where CustId = {custId}", _sqlConnection);
            var cmdInsert =
                new SqlCommand($"Insert Into CreditRisks (FirstName, LastName) Values ('{fName}', '{lName}')",
                    _sqlConnection);

            // Это будет получено из объекта подключения.
            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();

                // Включить команды в транзакцию.
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                // Выполнить команды.
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                // Эмулировать ошибку.
                if (throwEx)
                {
                    // Возникла ошибка, связанная с базой данных! Отказ транзакции...
                    throw new Exception("Sorry! Database error! Tx failed...");
                }

                // Зафиксировать транзакцию!
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Любая ошибка приведет к откату транзакции.
                // Использовать условную операцию для проверки на предмет null.
                tx?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion
    }
}
