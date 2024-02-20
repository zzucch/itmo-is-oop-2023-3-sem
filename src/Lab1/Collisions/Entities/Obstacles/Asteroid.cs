using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;

public class Asteroid : INormalSpaceObstacle
{
    private const int AsteroidPhysicalDamage = 25;

    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Damage.Physical(AsteroidPhysicalDamage));
    }
}