using System;
using System.Collections.Generic;
namespace FiguryLib {
    class Okrag : Figura, IMierzalna1D {
        private Punkt _srodek;
        public Punkt Srodek { 
            get => _srodek;
            set {
                if(value == null)
                    throw new ArgumentException("Punkt nie może być null");

                _srodek = value;
            }
        }

        private int _promien;
        public int Promien { 
            get => _promien;
            set {
                if(value < 0)
                    _promien = 0;
                else
                    _promien = value;
            }
        }

        public double Dlugosc { 
            get => 2 * Math.PI * Promien;
        }
        public Okrag(Punkt srodek, int promien = 1) {
            Srodek = srodek;
            Promien = promien;
            DefaultColor = ConsoleColor.Cyan;
        }

        public Okrag() : this(new Punkt(0,0), 1) {}

        public override string ToString() {
            return $"O({Srodek}, {Promien})";
        }

        public override void Rysuj() {
            Console.ResetColor();
            Console.ForegroundColor = this.DefaultColor;
            Console.WriteLine(this + $" dlugosc={Dlugosc:F2}");
            Console.ResetColor();
        }
    }

    class Kolo: Okrag, IMierzalna2D {
        public Kolo(Punkt srodek, int promien = 2) : base(srodek, promien) {
            DefaultColor = ConsoleColor.Red;
        }

        public Kolo() : this(new Punkt(0,0), 2) {}

        public double Pole { 
            get => Math.Round(Math.PI * Promien * Promien, 2);
        }

        public double Obwod {
            get => Math.Round(2 * Math.PI * Promien, 2);
        }

        public override string ToString() {
            return $"K({Srodek}, {Promien})";
        }

        public override void Rysuj() {
            Console.ResetColor();
            Console.ForegroundColor = this.DefaultColor;
            Console.WriteLine(this + $" obwod={Obwod:F2}, pole={Pole:F2}");
            Console.ResetColor();
        }
    }

    public class Ekran
    {
        private List<Figura> figury = new List<Figura>();
        public void Dodaj(Figura f) => figury.Add(f);
        public void Usun(Figura f) => figury.Remove(f);
        public void Rysuj() => figury.ForEach(f => f.Rysuj());

        public double SumarycznaDlugosc() {
            double suma = 0;
            foreach (var f in figury)
            {
                if (f is IMierzalna1D)
                {
                    suma += ((IMierzalna1D) f).Dlugosc;
                }
            }
            return Math.Round(suma, 2);
        }
        public double SumarycznePole() {
            double suma = 0;
            foreach (var f in figury)
            {
                if (f is IMierzalna2D)
                {
                    suma += ((IMierzalna2D) f).Pole;
                }
            }
            return Math.Round(suma, 2);
        }
    }
}