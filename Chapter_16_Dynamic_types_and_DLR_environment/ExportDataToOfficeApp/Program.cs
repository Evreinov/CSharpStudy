using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Создать псевдоним для объектной модели Excel.
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsInStock = new List<Car>
            {
                new Car {Color = "Green", Make = "VM", PetName = "Mary"},
                new Car {Color = "Red", Make = "Saab", PetName = "Mel"},
                new Car {Color = "Black", Make = "Ford", PetName = "Hank"},
                new Car {Color = "Yellow", Make = "BMW", PetName = "Davie"}
            };
            //ExportToExcelManual(carsInStock);
            ExportToExcel(carsInStock);
            Console.ReadLine();
        }

        /// <summary>
        /// Взаимодействие с COM с использованием динамических данных. 
        /// </summary>
        static void ExportToExcel(List<Car> carsInStock)
        {
            // Загрузить Excel и затем создать новую пустую рабочую книгу.
            Excel.Application excelApp = new Excel.Application();
            //excelApp.Visible = true; // Сделать пользовательский интерфейс Excel видимым на рабочем столе.
            excelApp.Workbooks.Add();
            // В этом примере используется единственный рабочий лист.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            // Установить заголовки столбцов в ячейках.
            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "Pet Name";
            // Отобразить все данные из List<Car> на ячейки электронной таблицы.
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }
            // Придать симпатичный вид табличным данным.
            workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            // Сохранить файл, завершить работу Excel и отобразить сообщение пользователю.
            workSheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("The Inventory.xlsx file has been saved to your app folder.");
            // Файл Inventiry.xlsx сохранен в папке приложения.
        }

        /// <summary>
        /// Взаимодействие с COM без использованием динамических данных. 
        /// </summary>
        static void ExportToExcelManual(List<Car> carsInStock)
        {
            Excel.Application excelApp = new Excel.Application();

            // Потребуется пометить пропущенные параметры!
            excelApp.Workbooks.Add(Type.Missing);

            // Потребуется привести объект Object к _Worksheet! 
            Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

            // Потребуется привести каждый объект Object к Range
            // и затем обратиться к низкоуровневому свойству Value2!
            ((Excel.Range)excelApp.Cells[1, "A"]).Value2 = "Make";
            ((Excel.Range)excelApp.Cells[1, "B"]).Value2 = "Color";
            ((Excel.Range)excelApp.Cells[1, "C"]).Value2 = "Pet Name";

            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                // Потребуется привести каждый объект Object к Range
                // и затем обратиться к низкоуровневому свойству Value2!
                ((Excel.Range)workSheet.Cells[row, "A"]).Value2 = c.Make;
                ((Excel.Range)workSheet.Cells[row, "B"]).Value2 = c.Color;
                ((Excel.Range)workSheet.Cells[row, "C"]).Value2 = c.PetName;
            }

            // Потребуется вызвать метод get_Range()
            // с указателем всех пропущенных аргументов!
            excelApp.Range["A1", Type.Missing].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2,
                Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing);

            // Потребуется указать все пропущенные необязательные аргументы!
            workSheet.SaveAs($@"{Environment.CurrentDirectory}\InventoryManual.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            Console.WriteLine("The InventoryManual.xslx file has been saved to your app folder");
        }
    }
    }
