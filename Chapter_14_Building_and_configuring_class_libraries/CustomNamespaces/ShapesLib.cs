namespace MyShapes
{
    public class Circle { /* Интрересные члены... */ }
    public class Hexagon { /* Более интрересные члены... */ }
    public class Square { /* Даже ещё более интрересные члены... */ }
}

namespace My3DShapes
{
    public class Circle { /* Интрересные члены... */ }
    public class Hexagon { /* Более интрересные члены... */ }
    public class Square { /* Даже ещё более интрересные члены... */ }
}

// Вложенные пространства имен. Способ 1.
namespace Chapter14
{
    namespace MyShapes
    {
        public class Circle { /* Интрересные члены... */ }
        public class Hexagon { /* Более интрересные члены... */ }
        public class Square { /* Даже ещё более интрересные члены... */ }
    }
}

// Вложенные пространства имен. Способ 2 (через точку).
namespace Chapter14.My3DShapes
{
    public class Circle { /* Интрересные члены... */ }
    public class Hexagon { /* Более интрересные члены... */ }
    public class Square { /* Даже ещё более интрересные члены... */ }
}