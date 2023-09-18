using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Vaklas : SpaceShip
{
    public Vaklas(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 200;
        HullStrength = HullStrength.CLass2;
        MassDimensionalCharacteristics = MassDimensional.Medium;
    }

    private IEngine ImpulseEngine { get; init; } = new ImpulseEngineE();
    private IEngine JumpEngine { get; init; } = new GammaJumpEngine();
}