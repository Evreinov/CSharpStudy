using System;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    internal class MoreData
    {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            // Вызывается в течении процесса сериализации.
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            // Вызывается, когда процесс десерилизации завершен.
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }
    }
}
