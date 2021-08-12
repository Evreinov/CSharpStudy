using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            HorseAndBuggy mule = new HorseAndBuggy();
        }
    }

    // Этот класс может быть сохранен на диске.
    [Serializable]
    public class Motorcycle
    {
        // Однако это поле сохраняться не будет.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // Эти поля остаются сериализируемымы.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }

    //[Serializable, Obsolete("Use another vehicle!")]
    // Или
    //[SerializableAttribute]
    //[ObsoleteAttribute("Use another vehicle!")]
    // Или
    [Serializable]
    [Obsolete("Use another vehicle!")]
    public class HorseAndBuggy { }
}
