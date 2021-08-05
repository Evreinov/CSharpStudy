using System;

namespace LazyObjectInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lazy Instantiation *****\n");
            // В этом вызывающем коде получение всех композиций не производится, 
            // но косвенно все равно создаются 10 000 объектов!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();

            // размещение объекта AllTracks происходит
            // только в случае вызова метода GetAllTracks().
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();
            Console.ReadLine();
        }
    }
}
