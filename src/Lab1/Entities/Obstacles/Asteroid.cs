using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : IObstacle
{
    private const int AsteroidPhysicalDamage = 25;
    public void DoDamage(ISpaceShip ship)
    {
        ship.TakeDamage(new Damage(DamageType.Physical, AsteroidPhysicalDamage));
    }
}