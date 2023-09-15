using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : SpaceShip
{
    public Vaklas(int fuel)
    {
        FuelLeft = fuel;

        HitPointsLeft = 200;
        HullStrength = HullStrength.CLass2;
        MassDimensionalCharacteristics = MassDimensional.Medium;
    }
}