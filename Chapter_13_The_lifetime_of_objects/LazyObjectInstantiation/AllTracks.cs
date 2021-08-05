using System;

namespace LazyObjectInstantiation
{
    /// <summary>
    /// Представляет все композиции в проигрыватели.
    /// </summary>
    class AllTracks
    {
        // Наш проигрыватель может содержать
        // максимум 10 000 композиций.
        private Song[] allSongs = new Song[10000];

        public AllTracks()
        {
            // Предположим, что здесь производится
            // заполнение массива объектов Song.
            Console.WriteLine("Filling up the songs!");
        }

    }
}
