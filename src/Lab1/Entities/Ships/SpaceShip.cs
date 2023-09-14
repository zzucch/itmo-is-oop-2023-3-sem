using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class SpaceShip
{
    protected SpaceShip()
    {
        HpLeft = 1;
        IsCrewAlive = true;
        HullStrength = HullStrength.Class1;
        MdCharacteristics = MassDimensional.Low;
        Deflectors = new List<IDeflector>();
    }

    protected int HpLeft { get; set; }
    protected int FuelLeft { get; set; }
    protected bool IsCrewAlive { get; set; }
    protected HullStrength HullStrength { get; init; }
    protected MassDimensional MdCharacteristics { get; init; }
    protected IList<IDeflector> Deflectors { get; init; }

    public void Deflect(Obstacle? obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        foreach (IDeflector deflector in Deflectors)
        {
            if (deflector.IsFunctioning && deflector.Deflect(obstacle))
            {
                if (!deflector.IsFunctioning)
                {
                    Deflectors.Remove(deflector);
                }

                return;
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