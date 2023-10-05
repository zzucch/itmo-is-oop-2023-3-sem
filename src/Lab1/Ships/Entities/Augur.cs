using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Augur : SpaceShip
{
    public Augur(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 200;
        HullStrength = HullStrength.Class3;
        MassDimensionalCharacteristics = MassDimensional.High;

        // todo: implement deflectors
    }

    private IEngine ImpulseEngine { get; init; } = new ImpulseEngineE();
    private IEngine JumpEngine { get; init; } = new AlphaJumpEngine();

    public override RouteSegmentResult Travel(RouteSegment routeSegment)
    {
        throw new System.NotImplementedException();
    }
}