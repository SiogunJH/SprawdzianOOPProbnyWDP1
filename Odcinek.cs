using System;

namespace FiguryLib
{
    public class Odcinek : Figura, IMierzalna1D, IEquatable<Odcinek>
    {
        public Punkt P1 { get; private set; }
        public Punkt P2 { get; private set; }

        public Odcinek() : this(new Punkt(), new Punkt())
        { }

        public Odcinek(Punkt p1, Punkt p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Punkt nie może być null");
            P1 = p1; P2 = p2;
            DefaultColor = ConsoleColor.Blue;
        }

        public double Dlugosc =>
            Math.Round(Math.Sqrt((P2.X - P1.X) * (P2.X - P1.X) + (P2.Y - P1.Y) * (P2.Y - P1.Y)), 2);

        public override string ToString() => $"L({P1}, {P2})";

        public override void Rysuj()
        {
            Console.ResetColor();
            Console.ForegroundColor = this.DefaultColor;
            Console.WriteLine(this + $" dlugosc={Dlugosc:F2}");
            Console.ResetColor();
        }

        public bool Equals(Odcinek other) =>
            other != null && P1 == other.P1 && P2 == other.P2;
    }
}