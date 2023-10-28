using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;

public class SpaceWhales : INitriteNebulaObstacle
{
    private const int SpaceWhalePhysicalDamage = 1000;

    public SpaceWhales(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; }

    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship is IEmitterSpaceShip
            ? new ShipDeflectionResult(DeflectorResult: null, HullResult: null)
            : ship.TakeDamage(new Damage.Physical(SpaceWhalePhysicalDamage * Amount));
    }
}