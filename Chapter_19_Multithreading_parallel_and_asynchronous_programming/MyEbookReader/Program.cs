using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyEbookReader
{
    internal static class Program
    {
        private static string _theEBook;

        private static void Main(string[] args)
        {
            GetBook();
            Console.ReadLine();
        }

        private static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                _theEBook = eArgs.Result;
                Console.WriteLine("Download complete.");
                GetStats();
            };
            // Загрузить электронную книгу Чарльза Диккенса "A Tale of Two Cities".
            // Может понадобиться двукрастное выполнение этого кода, если ранее вы 
            // не посещали данный сайт, поскольку при первом его посещение появляется
            // окно с сообщением, предотвращающее нормальное выполнение кода.
            wc.DownloadStringAsync(new Uri("https://www.gutenberg.org/files/2600/2600-0.txt"));
        }

        private static void GetStats()
        {
            // Получить слова из электронной книги.
            string[] words = _theEBook.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
                StringSplitOptions.RemoveEmptyEntries);
            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    // Найти 10 наиболее часто встречающихся слов.
                    tenMostCommon = FindTenMostCommon(words);
                },
                () =>
                {
                    // Получить самое длинное слово.
                    longestWord = FindLongestWord(words);
                });

            // Когда все задачи завершиины, посроить строку,
            // показывающую всю статистику в окне сообщений.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat("Longest word is: {0}", longestWord); // Самое длинное слово.

            bookStats.AppendLine();

            Console.WriteLine(bookStats.ToString(), "Book info"); // Информация о книге.
        }

        private static string FindLongestWord(string[] words)
        {
            return (from w in words
                    orderby w.Length descending
                    select w).FirstOrDefault();
        }

        private static string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word
                into g
                                 orderby g.Count() descending
                                 select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }
    }
}
