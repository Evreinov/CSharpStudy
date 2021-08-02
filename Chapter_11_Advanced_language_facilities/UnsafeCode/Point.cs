namespace UnsafeCode
{
    struct Point
    {
        public int x;
        public int y;
        public override string ToString() => $"({x}, {y})";
    }

    class PointRef
    {
        public int x;
        public int y;
        public override string ToString() => $"({x}, {y})";
    }
}
