using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : SpaceShip
{
    public Shuttle(int fuel)
    {
        FuelLeft = fuel;
        IsCrewAlive = true;

        HitPointsLeft = 100;
        HullStrength = HullStrength.Class1;
        MdCharacteristics = MassDimensional.Low;
    }
}