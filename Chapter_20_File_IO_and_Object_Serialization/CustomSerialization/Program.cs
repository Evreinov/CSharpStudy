using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace CustomSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Serialization *****");
            // Вспомните, что этот тип реализует интерфейс ISerializable.
            StringData myData = new StringData();

            // Сохранить экземпляр в локальный файл в формате SOAP.
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("MyData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myData);
            }

            MoreData myMoreData = new MoreData();

            using (Stream fStream = new FileStream("MoreData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myMoreData);
            }

            Console.ReadLine();
        }
    }
}
