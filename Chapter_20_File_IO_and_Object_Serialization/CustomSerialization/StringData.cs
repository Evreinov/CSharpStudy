using System;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    class StringData : ISerializable
    {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";

        public StringData() { }

        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            // Восстановить переменные-члены из потока.
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Наполнить объект SerializationInfo форматированными данными.
            info.AddValue("First_Item", dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }
    }
}
