using System;

// После перечисления операторов using.
// Перечисляются атрибуту сборки или модуля.
// Обеспечить совместимость с CLS для всех открытых типов в данной сборке.
[assembly: CLSCompliant(true)]
// Далее может следовать ваше пространство (пространства) имен и типы.
// Но лучше атрибуты уровня сборки записывать в файл AssemblyInfo.cs.

namespace AttributedCarLibrary
{
    // Специальный атрибут.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string vehicalDescription) =>
            Description = vehicalDescription;
        public VehicleDescriptionAttribute() { }
    }

    // Каждому классу назначаем описание с помощью именованного свойства.
    [Serializable]
    [VehicleDescription(Description ="My rocking Harley")]
    public class Motorcycle { }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy { }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago { public ulong notCompliant; } // Тип ulong не соотвествует спецификации CLS.
}
