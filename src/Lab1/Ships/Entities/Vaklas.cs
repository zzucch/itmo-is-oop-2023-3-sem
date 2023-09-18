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

    private ImpulseEngineE ImpulseEngine { get; init; } = new();
    private GammaJumpEngine JumpEngine { get; init; } = new();
}