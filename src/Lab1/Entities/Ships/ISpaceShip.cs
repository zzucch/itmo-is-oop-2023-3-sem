using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface ISpaceShip
{
    int HpLeft { get; }
    bool IsIntact { get; }
    bool IsCrewAlive { get; }
    HullStrength HullStrength { get; }
    MassDimensional MdCharacteristics { get; }
}