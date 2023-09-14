using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : SpaceShip
{
    public Shuttle(int fuel, Collection<IDeflector>? deflectors)
    {
        if (deflectors is null)
        {
            throw new ArgumentNullException(nameof(deflectors));
        }

        HpLeft = 100;
        FuelLeft = fuel;
        IsCrewAlive = true;
        HullStrength = HullStrength.Class1;
        MdCharacteristics = MassDimensional.Low;

        Deflectors = new List<IDeflector>();
        foreach (IDeflector deflector in deflectors)
        {
            Deflectors.Add(deflector);
        }
    }
}