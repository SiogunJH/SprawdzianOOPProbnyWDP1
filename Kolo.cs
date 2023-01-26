using System;

namespace FiguryLib
{
    public class Kolo : Okrag, IMierzalna2D
    {
        public double Pole
        {
            get
            {
                return Promien * Promien * Math.PI;
            }
        }
        public double Obwod
        {
            get
            {
                return Dlugosc;
            }
        }

        //ZMIENNE
        public new ConsoleColor DefaultColor { get; protected set; } = ConsoleColor.Red;

        //KONSTRUKTOR
        public Kolo(Punkt srodek, int promien = 2) : base(srodek, promien)
        {
            Srodek = srodek;
            Promien = promien;
        }

        //FUNKCJE
        public override string ToString() => $"K({Srodek}, {Promien})";

        public override void Rysuj()
        {
            Console.ResetColor();
            Console.ForegroundColor = this.DefaultColor;
            Console.WriteLine(String.Format("K({0}, {1}) dlugosc={2:F2}, pole={3:F2}", Srodek, Promien, Dlugosc, Pole));
            Console.ResetColor();
        }
    }
}