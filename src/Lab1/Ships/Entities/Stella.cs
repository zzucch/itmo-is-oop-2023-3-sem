using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Stella : SpaceShip
{
    public Stella(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 200;
        HullStrength = HullStrength.Class1;
        MassDimensionalCharacteristics = MassDimensional.Low;

        // todo: implement deflectors
    }

    private IEngine ImpulseEngine { get; init; } = new ImpulseEngineC();
    private IEngine JumpEngine { get; init; } = new OmegaJumpEngine();
}