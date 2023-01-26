using System;

namespace FiguryLib
{
    // immutable
    public class Punkt : Figura, IEquatable<Punkt>
    {
        public readonly int X, Y;
        public Punkt(int x = 0, int y = 0) { X = x; Y = y; }
        public override string ToString() => $"P({X}, {Y})";
        public bool Equals(Punkt other) =>
            other != null && X == other.X && Y == other.Y;
    }
}