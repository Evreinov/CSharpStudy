using System;
using System.Diagnostics;
using System.Linq;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Processes *****\n");
            ListAllRunningProcesses();
            GetSpecificProcess();

            // Запросить у пользователя PID и вывести набор активных потоков.
            Console.WriteLine("***** Enter PID of process to investigate *****");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);

            EnumThreadsForPid(theProcID);
            EnumModsForPid(theProcID);
            //StartAndKillProcess();
            StartAndKillProcessV2();
            Console.ReadLine();
        }

        /// <summary>
        /// Перечисление выполняющихся процессов.
        /// </summary>
        static void ListAllRunningProcesses()
        {
            // Получить все процессы на локальной машине, упорядочные по PID.
            var runningProcs = from proc in Process.GetProcesses(".") // Точка - это локальный компьютер.
                               orderby proc.Id
                               select proc;

            // Вывести для каждого процесса идентификатор PID и имя.
            foreach (var p in runningProcs)
            {
                string info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************************\n");
        }

        /// <summary>
        /// Исследование конкретного процесса.
        /// Если процесс с PID, равным 987, не существует,
        /// то сгенерируется исключение во время выполнения.
        /// </summary>
        static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Исследование набора потоков процесса.
        /// </summary>
        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // Вывести статические сведения по каждому потоку в указанном процессе.
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;
            foreach (ProcessThread pt in theThreads)
            {
                string info = $"-> Thread ID: {pt.Id}\t" +
                    $"Start Time: {pt.StartTime.ToShortTimeString()}\t" +
                    $"Priority: {pt.PriorityLevel}";
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************************\n");
        }

        /// <summary>
        /// Исследование набора модулей процесса.
        /// </summary>
        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Here are the loaded modules for: {0}", theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;
            foreach (ProcessModule pm in theMods)
            {
                string info = $"-> Mod Name: {pm.ModuleName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************************\n");
        }

        /// <summary>
        /// Запуск и останов процессов программным образом.
        /// </summary>
        static void StartAndKillProcess()
        {
            Process ffProc = null;
            
            // Запустить FireFox и перейти на сайт facebook.com.
            try
            {
                ffProc = Process.Start("Firefox.exe", "www.facebok.com");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("--> Hit enter to kill {0}...", ffProc.ProcessName);
            Console.ReadLine();

            // Уничтожить процесс firefox.
            try
            {
                ffProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Управление запуском процесса с использованием класса
        /// ProcessStartInfo.
        /// </summary>
        static void StartAndKillProcessV2()
        {
            Process ffProc = null;

            // Запустить FireFox и перейти на сайт facebook.com.
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("Firefox.exe", "www.facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                ffProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("--> Hit enter to kill {0}...", ffProc.ProcessName);
            Console.ReadLine();

            // Уничтожить процесс firefox.
            try
            {
                ffProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
