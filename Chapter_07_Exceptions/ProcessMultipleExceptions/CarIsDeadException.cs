using System;

namespace ProcessMultipleExceptions
{
    #region Способ первый
    /*
    // Это специальное исключение описывает детали условия выхода автомобиля из строя.
    // (Не забывайте, что можно также просто расширить класс Exception).
    public class CarIsDeadException : ApplicationException
    {
        private string messageDetails = String.Empty;

        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string message, string cause, DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // Переопределить свойство Exception.Message.
        public override string Message => $"Car Error Message: {messageDetails}";
    }  
    */
    #endregion

    #region Способ второй
    /*
    // Без переопределения виртуального методв Message()
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        // Передача сообщения конструктору родительского класса.
        public CarIsDeadException(string message, string cause, DateTime time) : base (message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
    */
    #endregion

    #region Способ третий
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public CarIsDeadException() { }
        public CarIsDeadException(string message) : base (message) { }
        public CarIsDeadException(string message, System.Exception inner) : base(message, inner) { }
        protected CarIsDeadException (
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        // Любые дополнительные специфльные свойства, конструкторы и члены данных...

        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException(string message, string cause, DateTime time) : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
    #endregion
}
