namespace SimpleUtilityClass
{
    // Статические классы могут содержать только статические члены!
    //static class TimeUtilClass
    //{
    //    public static void PrintTime() => Console.WriteLine(DateTime.Now.ToShortTimeString());
    //    public static void PrintDate() => Console.WriteLine(DateTime.Today.ToShortDateString());
    //}

    // Импортирование статических членов классов Console и DateTime.
    using static System.Console;
    using static System.DateTime;

    static class TimeUtilClass
    {
        public static void PrintTime() => WriteLine(Now.ToShortTimeString());
        public static void PrintDate() => WriteLine(Today.ToShortDateString());
    }
}
