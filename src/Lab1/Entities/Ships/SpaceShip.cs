using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class SpaceShip
{
    protected int FuelLeft { get; set; }
    protected int HitPointsLeft { get; set; } = 1;
    protected bool IsCrewAlive { get; set; } = true;
    protected HullStrength HullStrength { get; init; } = HullStrength.Class1;
    protected MassDimensional MassDimensionalCharacteristics { get; init; } = MassDimensional.Low;
    protected IDeflector? Deflector { get; init; }

    public void Deflect(Obstacle? obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (Deflector is not null)
        {
            if (Deflector.IsFunctioning && Deflector.TryDeflect(obstacle))
            {
                return;
            }
        }

        HullDeflect(obstacle);
    }

    private void HullDeflect(Obstacle obstacle)
    {
        if (HitPointsLeft > (int)obstacle.DamageDealt)
        {
            HitPointsLeft -= (int)obstacle.DamageDealt;
        }
        else
        {
            HitPointsLeft = 0;
            IsCrewAlive = false;
        }
    }
}