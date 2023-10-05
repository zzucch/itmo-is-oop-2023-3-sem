using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Meridian : SpaceShip
{
    public Meridian(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 200;
        HullStrength = HullStrength.Class2;
        MassDimensionalCharacteristics = MassDimensional.Medium;

        // todo: implement deflectors
    }

    private IEngine ImpulseEngine { get; init; } = new ImpulseEngineE();
}