﻿using System;

namespace BasicInheritance
{
    // MiniVan "является" Car.
    sealed class MiniVan : Car // Множественное наследование классов в языке C# не разрешено!
                               // Ключевое слово sealed (запечатанный) не позволяет
                               // создавать классы, производные от него.
    {
        public void TestMethod()
        {
            // Нормально! Доступ к открытым членам родительского
            // типа в производном типе возможен.
            Speed = 10;

        // Ошибка! Нельзя обращаться к закрытым членам
        // родительского типа из производного типа!
        //currSpeed = 10;
        }
    }

    // Ошибка! Нельзя расширять класс, помеченный ключевым словом sealed!
    //class DeluxeMiniVan : MiniVan { }
    //class MyString : String { }
}
