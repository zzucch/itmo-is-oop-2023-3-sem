using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : ISpaceShip
{
    public Shuttle()
    {
        HpLeft = 100;
        IsIntact = true;
        IsCrewAlive = true;
        HullStrength = HullStrength.Class1;
        MdCharacteristics = MassDimensional.Low;
    }

    public int HpLeft { get; }
    public bool IsIntact { get; }
    public bool IsCrewAlive { get; }
    public HullStrength HullStrength { get; }
    public MassDimensional MdCharacteristics { get; }
}