using System;

namespace FiguryLib
{
    public interface IMierzalna2D : IMierzalna1D
    {
        double Pole { get; }
        double Obwod { get; }
    }
}