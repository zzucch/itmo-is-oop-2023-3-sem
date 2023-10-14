using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhales : IObstacle
{
    private const int SpaceWhalePhysicalDamage = 1000;

    public SpaceWhales(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; set; }

    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Damage(DamageType.Physical, SpaceWhalePhysicalDamage * Amount));
    }
}