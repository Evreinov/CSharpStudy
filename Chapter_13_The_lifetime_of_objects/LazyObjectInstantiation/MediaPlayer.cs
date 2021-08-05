using System;

namespace LazyObjectInstantiation
{
    /// <summary>
    /// Объект MediaPlayer имеет объекты AllTracks.
    /// </summary>
    class MediaPlayer
    {
        // Предположим, что эти методы делают что-то полезное.
        public void Play() { /* Воспроизведение композиции */ }
        public void Pause() { /* Пауза в воспроизведении */ }
        public void Stop() { /* Останов воспроизведения */ }

        // Обычное создание объектов.
        //private AllTracks allSongs = new AllTracks();
        //public AllTracks GetAllTracks()
        //{
        //    // Возвратить все композиции.
        //    return allSongs;
        //}

        // Ленивое создание объектов.
        //private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();
        //public AllTracks GetAllTracks()
        //{
        //    // Возвратить все композиции.
        //    return allSongs.Value;
        //}

        // Использовать лямбда-выражение для добавления дополнительного
        // кода, который выполняется при создании объекта AllTracks.
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() =>
        {
            Console.WriteLine("Greating AllTracks object!");
            return new AllTracks();
        });
        public AllTracks GetAllTracks()
        {
            // Возвратить все композиции.
            return allSongs.Value;
        }
    }
}
