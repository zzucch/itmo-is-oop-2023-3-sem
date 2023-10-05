using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Vaklas : SpaceShip
{
    public Vaklas(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 200;
        HullStrength = HullStrength.Class2;
        MassDimensionalCharacteristics = MassDimensional.Medium;

        // todo: implement deflectors
    }

    private IEngine ImpulseEngine { get; init; } = new ImpulseEngineE();
    private IEngine JumpEngine { get; init; } = new GammaJumpEngine();

    public override RouteSegmentResult Travel(RouteSegment routeSegment)
    {
        throw new System.NotImplementedException();
    }
}