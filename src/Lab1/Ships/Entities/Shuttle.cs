using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Shuttle : SpaceShip
{
    public Shuttle(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 100;
        HullStrength = HullStrength.Class1;
        MassDimensionalCharacteristics = MassDimensional.Low;
    }

    private IEngine ImpulseEngine { get; init; } = new GammaJumpEngine();

    public override RouteSegmentResult Travel(RouteSegment routeSegment)
    {
        throw new System.NotImplementedException();
    }
}