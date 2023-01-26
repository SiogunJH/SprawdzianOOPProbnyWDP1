using System;
using System.Collections.Generic;
namespace FiguryLib
{
    public class Ekran
    {
        private List<Figura> figury = new List<Figura>();
        public void Dodaj(Figura f) => figury.Add(f);
        public void Usun(Figura f) => figury.Remove(f);
        public void Rysuj() => figury.ForEach(f => f.Rysuj());

        public double SumarycznaDlugosc()
        {
            double suma = 0;

            foreach (var figura in figury)
            {
                Console.WriteLine(figura);
            }

            return Math.Round(suma, 2);
        }
        public double SumarycznePole() => throw new NotImplementedException();
    }
}