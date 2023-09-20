using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip
{
    protected int FuelLeft { get; set; }
    protected int HitPointsLeft { get; set; } = 1;
    protected bool IsCrewAlive { get; set; } = true;
    protected HullStrength HullStrength { get; init; } = HullStrength.Class1;
    protected MassDimensional MassDimensionalCharacteristics { get; init; } = MassDimensional.Low;
    protected IDeflector? Deflector { get; init; }

    public void Deflect(Obstacle obstacle)
    {
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
        int damageDealt = obstacle.DamageDealt;

        if (HitPointsLeft > damageDealt)
        {
            HitPointsLeft -= damageDealt;
        }
        else
        {
            HitPointsLeft = 0;
            IsCrewAlive = false;
        }
    }
}