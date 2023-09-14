using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : ISpaceShip
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

    private int HpLeft { get; set; }
    private int FuelLeft { get; }
    private bool IsCrewAlive { get; set; }
    private HullStrength HullStrength { get; }
    private MassDimensional MdCharacteristics { get; }
    private List<IDeflector> Deflectors { get; }

    public void Deflect(IObstacle? obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        foreach (IDeflector deflector in Deflectors)
        {
            if (deflector.IsFunctioning)
            {
                if (deflector.Deflect(obstacle))
                {
                    return;
                }
            }
        }

        if (HpLeft > (int)obstacle.DamageDealt)
        {
            HpLeft -= (int)obstacle.DamageDealt;
            return;
        }

        HpLeft = 0;
        IsCrewAlive = false;
    }
}