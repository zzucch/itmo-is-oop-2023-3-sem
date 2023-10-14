using Itmo.ObjectOrientedProgramming.Lab1.Damage.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Obstacles;

public class Meteorite : INormalSpaceObstacle
{
    private const int MeteoritePhysicalDamage = 100;
    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Models.Damage(DamageType.Physical, MeteoritePhysicalDamage));
    }
}