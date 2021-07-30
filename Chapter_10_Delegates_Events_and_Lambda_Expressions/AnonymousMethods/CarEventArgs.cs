using System;

namespace AnonymousMethods
{
    /// <summary>
    /// Специальный аргумент событий.
    /// </summary>
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs (string message)
        {
            msg = message;
        }
    } 
}
