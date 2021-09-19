// Скомпилировать:
// ilasm /dll .\CILTypes.il

// Открыть скомпилированную сборку с помощью ildasm.exe

// Проверить содержимое сборки.
// peverify .\CILTypes.dll

// Указание ссылки на внешние сборки CIL. Явно добавлять ссылку на сборку mscorlib не обязательно.
.assembly extern mscorlib
{
    .publickeytoken = ( B7 7A 5C 56 19 34 E0 89 )
    .ver 4:0:0:0
}

// Определение текущей сборки в CIL.
.assembly CILTypes
{
    .ver 1:0:0:0
}
.module CILTypes.dll // Модуль нашей однофайловой сборки, т.к. сборка является однофайловой.

// Определение простанства имен в CIL
.namespace MyNamespace 
{   
    // Определение интерфейса (тоже, используется директива class, но с атрибутом interface).
    .class public interface IMyInterface { }

    // Расширение интерфейсов в CIL.
    .class public interface IMyOtherInterface
        implements MyNamespace.IMyInterface { }

    // Предполагается базовый класс System.Object.
    .class public MyBaseClass 
    {
        // Поля класса.
        .field private string stringField = "hello!"
        .field private int32 intField = int32(42)

        // Определение конструкторов типа в CIL(ctor). На заметку! cctor - конструктор класса (статический конструктор).
        .method public hidebysig specialname rtspecialname
        instance void .ctor(string s, int32 i) cil managed
        {
            // Код реализации.
        }

        // Определение свойств.
        .method public hidebysig specialname
        instance string get_TheString() cil managed
        {
            // Добавить код реализации...
        }
        .method public hidebysig specialname
        instance void set_TheString(string 'value') cil managed
        {
            // Добавить код реализации...
        }
        .property instance string TheString()
        {
            .get instance string
            MyNamespace.MyBaseClass::get_TheString()
            .set instance void
            MyNamespace.MyBaseClass::set_TheString(string)
        }

        // Определение параметров членов.
        // C# аналог public static void MyMethod(int inputInt, ref int refInt, ArrayList ar, out int outputInt) { }
        .method public hidebysig static 
        void MyMethod(int32 inputInt, int32& refInt, class [mscorlib]System.Collections.ArrayList ar, [out] int32& outputInt) cil managed
        {

        }

        // Директива .maxstack
        .method public hidebysig instance
        void Speak() cil managed
        {
            // Внутри области действия этого метода в стеке находится
            // в точности одно значение (строковый литерал). 
            .maxstack 1
            ldstr "Hello there..."
            call void [mscorlib]System.Console::WriteLine(string)
            ret
        }

        // Объявление локальных переменных в CIL.
        .method public hidebysig static void 
        MyLocalVariables() cil managed
        {
            .maxstack 8
            // Определить три локальных переменных.
            .locals init ([0] string myStr, [1] int32 myInt, [2] object myObj)
            // Загрузить строку в виртуальный стек выполнения.
            ldstr "CIL code is fun!"
            // Извлечь текущее значение и сохранить его в локальной переменной [0].
            stloc.0
            // Загрузить константу типа i4 (сокращение для int32) со значением 33.
            ldc.i4 33
            // Извлечь текущее значение и сохранить его в локальной переменной [1].
            stloc.1
            // Создать новый объект и поместить его в стек.
            newobj instance void [mscorlib]System.Object::.ctor()
            // Извлечь текущее значение и сохранить его в локальной переменной [2].
            stloc.2
            ret
        }

        // Отображение параметров на локальные переменные в CIL
        .method public hidebysig static int32 Add(int32 a, int32 b) cil managed
        {
            .maxstack 2
            ldarg.0 // Загрузить а в стек.
            ldarg.1 // Загрузить b в стек.
            add // Сложить оба значения.
            ret
        }

        // Представление итерационных конструкций в CIL
        .method public hidebysig static void CountToTen() cil managed
        {
            .maxstack 2
            .locals init ([0] int32 i) // Инициализировать локальную целочисленную переменную i.
            IL_0000: ldc.i4.0 // Загрузить это значение в стек.
            IL_0001: stloc.0 // Сохранить это значение по индексу 0.
            IL_0002: br.s IL_0008 // Перейти на метку IL_0008.
            IL_0004: ldloc.0 // Загрузить значение переменной по индексу 0.
            IL_0005: ldc.i4.1 // Загрузить значение 1 в стек.
            IL_0006: add // Добавить текущее значение по индексу 0.
            IL_0007: stloc.0
            IL_0008: ldloc.0 // Загрузить значение по индексу 0.
            IL_0009: ldc.i4.s 10 // Загрузить значение 10 в стек.
            IL_000b: blt.s IL_0004 // Меньше чем? Если да, то перейти на метку IL_0004.
            IL_000d: ret
        }
    }

    // Класс производный от MyBaseClass и реализующий интерфейс IMyInterface.
    .class public MyDerivedClass 
        extends MyNamespace.MyBaseClass 
        implements MyNamespace.IMyInterface { }

    // Определение структуры всегда является запечатанным.
    .class public sealed MyStruct
        extends [mscorlib]System.ValueType { }
    
    // Сокращенный синтаксис объявления структуры с использованием атрибута value.
    .class public sealed value MyStruct2 { }

    // Перечисление.
    .class public sealed MyEnum extends [mscorlib]System.Enum 
    { 
        .field public static literal valuetype 
        MyNamespace.MyEnum A = int32(0)
        .field public static literal valuetype 
        MyNamespace.MyEnum B = int32(1)
        .field public static literal valuetype 
        MyNamespace.MyEnum C = int32(2)
    }

    // Сокращенный синтаксис опеределения перечисления с использованием атрибута enum.
    .class public sealed enum MyEnum2 { }
}

// Определение вложенных пространств имен.
.namespace MyCompany1
{
    .namespace MyNamespace { }
}
.namespace MyCompany2.MyNamespace { }


