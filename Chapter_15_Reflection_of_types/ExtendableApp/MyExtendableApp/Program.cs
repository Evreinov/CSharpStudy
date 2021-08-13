using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonSnappableTypes;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace MyExtendableApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            do
            {
                // Запросить о необходимости загрузки оснастки.
                Console.WriteLine("\nWould you like to load a snapin? [Y, N]");
                // Получить имя типа.
                string answer = Console.ReadLine();
                // Желает ли пользователь завершить работу?
                if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                try
                {
                    LoadSnapin();
                }
                catch (Exception)
                {
                    // Найти олснастку не удалось.
                    Console.WriteLine("Sorry, can't find snapin");
                }
            } while (true);
        }

        static void LoadSnapin()
        {
            // Предоставить пользователю возможность выбора сборки для загрузки.
            OpenFileDialog dlg = new OpenFileDialog
            {
                // Установить в качестве начального каталога путь к текущему проекту.
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Filter = "assemblies (*.dll)|*.dll|All files (*.*)|*.*",
                FilterIndex = 1
            };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                // Пользователь закрыл диалоговое окно, не выбирая сборку.
                Console.WriteLine("User cancelled out of the open file dialog.");
                return;
            }
            if (dlg.FileName.Contains("CommonSnappableTypes"))
                // В CommonSnappableTypes нет оснасток.
                Console.WriteLine("CommonSnappableTypes has no snap-ins!");
            else if (!LoadExternalModule(dlg.FileName))
                // Интерфейс IAppFunctionality не реализован.
                Console.WriteLine("Nothing implements IAppFunctionality!");
        }

        private static bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                // Динамически загрузить выбранную сборку.
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                // Ошибка при запуске оснастки.
                Console.WriteLine($"An error occurred loading the snapin: {ex.Message}");
                return foundSnapIn;
            }
            // Получить все совместимые с IAppFunctionality классы в сборке.
            var theClassTypes = from t in theSnapInAsm.GetTypes()
                                where t.IsClass && (t.GetInterface("IAppFunctionality") != null)
                                select t;

            // Создать объект и вызвать метод DoIt().
            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;
                // Использовать позднее связывание для создание экземпляра типа.
                IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp?.DoIt();
                // Отобразить информацию о компании.
                DisplayCompanyData(t);
            }
            return foundSnapIn;
        }

        private static void DisplayCompanyData(Type t)
        {
            // Получить данные [CompanyInfo].
            var compInfo = from ci in t.GetCustomAttributes(false)
                           where (ci is CompanyInfoAttribute)
                           select ci;
            // отобразить данные.
            foreach (CompanyInfoAttribute c in compInfo)
            {
                Console.WriteLine($"More info about {c.CompanyName} can be found at {c.CompanyUrl}");
            }
        }
    }
}
