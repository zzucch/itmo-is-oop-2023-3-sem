using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class SpaceShip
{
    protected int HitPointsLeft { get; set; } = 1;
    protected int FuelLeft { get; set; }
    protected bool IsCrewAlive { get; set; } = true;
    protected HullStrength HullStrength { get; init; } = HullStrength.Class1;
    protected MassDimensional MdCharacteristics { get; init; } = MassDimensional.Low;
    protected IList<IDeflector> Deflectors { get; init; } = new List<IDeflector>();

    public void Deflect(Obstacle? obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        foreach (IDeflector deflector in Deflectors)
        {
            if (deflector.IsFunctioning && deflector.TryDeflect(obstacle))
            {
                if (!deflector.IsFunctioning)
                {
                    Deflectors.Remove(deflector);
                }

                return;
            }
        }

        if (HitPointsLeft > (int)obstacle.DamageDealt)
        {
            HitPointsLeft -= (int)obstacle.DamageDealt;
            return;
        }

        HitPointsLeft = 0;
        IsCrewAlive = false;
    }
}