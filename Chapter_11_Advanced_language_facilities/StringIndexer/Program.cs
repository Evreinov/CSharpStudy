using System;
using System.Data;

namespace StringIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");

            PersonCollection myPeople = new PersonCollection();

            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);

            // Получить объект лица Homer и вывести данные.
            Person homer = myPeople["Homer"];
            Console.WriteLine(homer.ToString());
            Console.WriteLine();

            MultiIndexerWithDataTable();

            Console.ReadLine();
        }

        /// <summary>
        /// Многомерный индексатор.
        /// </summary>
        static void MultiIndexerWithDataTable()
        {
            // Создать простой объект DataTable с тремя столбцами.
            DataTable myTable = new DataTable();
            myTable.Columns.Add(new DataColumn("FirstName"));
            myTable.Columns.Add(new DataColumn("LastName"));
            myTable.Columns.Add(new DataColumn("Age"));

            // Добавить строку в таблицу.
            myTable.Rows.Add("Mel", "Appleby", 60);

            // Использовать многомерный индексатор для вывода деталей первой строки.
            Console.WriteLine("First Name: {0}", myTable.Rows[0][0]);
            Console.WriteLine("Last Name: {0}", myTable.Rows[0][1]);
            Console.WriteLine("Age: {0}", myTable.Rows[0][2]);
        }
    }
}
