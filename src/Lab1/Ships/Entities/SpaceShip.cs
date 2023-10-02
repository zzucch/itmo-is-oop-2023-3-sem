using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip : ISpaceShip
{
    protected int FuelLeft { get; set; }
    protected int HitPointsLeft { get; set; } = 1;
    protected CrewState CrewState { get; set; } = CrewState.Alive;
    protected HullStrength HullStrength { get; init; } = HullStrength.Class1;
    protected MassDimensional MassDimensionalCharacteristics { get; init; } = MassDimensional.Low;
    protected IDeflector? Deflector { get; init; }

    public RouteSegmentResult Travel(RouteSegment routeSegment)
    {
        throw new System.NotImplementedException();
    }

    public void Deflect(IObstacle obstacle)
    {
        if (Deflector is not null)
        {
            if (Deflector.TryDeflect(obstacle))
            {
                return;
            }
        }

        HullDeflect(obstacle);
    }

    private void HullDeflect(IObstacle obstacle)
    {
        int damageDealt = obstacle.DamageDealt;

        if (HitPointsLeft > damageDealt)
        {
            HitPointsLeft -= damageDealt;
        }
        else
        {
            HitPointsLeft = 0;
            CrewState = CrewState.Dead;
        }
    }
}