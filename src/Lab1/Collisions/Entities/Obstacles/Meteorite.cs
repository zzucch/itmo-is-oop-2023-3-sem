using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;

public class Meteorite : INormalSpaceObstacle
{
    private const int MeteoritePhysicalDamage = 100;
    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Damage.Physical(MeteoritePhysicalDamage));
    }
}