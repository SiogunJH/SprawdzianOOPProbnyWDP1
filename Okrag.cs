using System;

namespace FiguryLib
{
    public class Okrag : Figura, IMierzalna1D
    {
        //ZMIENNE
        public Punkt _Srodek;
        public Punkt Srodek
        {
            get { return _Srodek; }
            set
            {
                if (value == null) throw new ArgumentException("Punkt nie może być null");
                _Srodek = value;
            }
        }
        public int _Promien;
        public int Promien
        {
            get { return _Promien; }
            set
            {
                if (value < 0) _Promien = 0;
                else _Promien = value;
            }
        }
        public double Dlugosc
        {
            get
            {
                return 2 * Promien * Math.PI;
            }
        }
        public new ConsoleColor DefaultColor { get; protected set; } = ConsoleColor.Cyan;

        //KONSTRUKTOR
        public Okrag(Punkt srodek, int promien = 1)
        {
            Srodek = srodek;
            Promien = promien;
        }

        //FUNKCJE
        public override string ToString() => $"O({Srodek}, {Promien})";

        public override void Rysuj()
        {
            Console.ResetColor();
            Console.ForegroundColor = this.DefaultColor;
            Console.WriteLine(String.Format("O({0}, {1}) dlugosc={2:F2}", Srodek, Promien, Dlugosc));
            Console.ResetColor();
        }
    }
}