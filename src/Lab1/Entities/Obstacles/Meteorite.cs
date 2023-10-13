using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : IObstacle
{
    private const int MeteoritePhysicalDamage = 100;
    public void DoDamage(ISpaceShip ship)
    {
        ship.TakeDamage(new Damage(DamageType.Physical, MeteoritePhysicalDamage));
    }
}