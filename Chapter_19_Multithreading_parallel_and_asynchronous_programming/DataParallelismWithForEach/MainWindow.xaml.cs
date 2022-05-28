using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        // Токен для обработки запроса на отмену.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow() => InitializeComponent();

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // Используется для сообщения всем рабочим потокам о необходимости останова.
            cancelToken.Cancel();
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            // Запустить новую задачу для обработки файлов.
            Task.Factory.StartNew(() => ProcessFiles());
        }

        private void ProcessFiles()
        {
            // Загрузить все файлы *.jpg и создать новый каталог
            // для модификации данных.
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @"ModifiedPictures";
            Directory.CreateDirectory(newDir);

            #region Обработать данные изображений в блокирующей манере.

            //foreach (string currentFile in files)
            //{
            //    string filename = Path.GetFileName(currentFile);

            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(newDir, filename));

            //        // Вывести идентификатор потока, обрабатывающего текущего изображения.
            //        this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
            //    }
            //}

            #endregion

            #region Обработать данные изображение в параллельном режиме!

            // Использовать экземпляр ParallelOptions для хранения CancelationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            try
            {
                Parallel.ForEach(files, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    string fileName = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, fileName));

                        // Вызвать Invoke() на объекте Dispather, чтобы позволить вторичным потокам
                        // получить доступ к элементам управления в безовасной к потокам м анере.
                        // Но данный метод должен быть запущен как задача (Task).
                        this.Dispatcher.Invoke((Action)delegate
                        {
                            this.Title = $"Processing {fileName} on thread {Thread.CurrentThread.ManagedThreadId}";
                        });
                    }
                });
                this.Dispatcher.Invoke((Action) delegate
                {
                    this.Title = "Done!"; // Готов!
                });
            }
            catch (Exception e)
            {
                this.Dispatcher.Invoke((Action) delegate
                {
                    this.Title = e.Message;
                });
            }

            #endregion

        }
    }
}
