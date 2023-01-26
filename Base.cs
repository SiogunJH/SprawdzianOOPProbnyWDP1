using System;
namespace FiguryLib
{
    class Base
    {
        public static void Main()
        {
            // klasa Kolo, modyfikacje
            Kolo k;
            try
            {
                k = new Kolo(null, -1);
                Console.WriteLine(k);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            k = new Kolo(new Punkt(1, 1), 1);
            Console.WriteLine(k);
            k.Srodek = new Punkt(0, 0);
            k.Promien = 5;
            k.Rysuj();
            k.Promien = -1;
            k.Rysuj();
        }
    }
}