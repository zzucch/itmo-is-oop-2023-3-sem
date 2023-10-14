using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : INormalSpaceObstacle
{
    private const int MeteoritePhysicalDamage = 100;
    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Damage(DamageType.Physical, MeteoritePhysicalDamage));
    }
}