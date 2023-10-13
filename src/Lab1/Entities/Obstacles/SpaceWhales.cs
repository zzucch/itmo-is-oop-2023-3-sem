using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhales : IObstacle
{
    private const int SpaceWhalePhysicalDamage = 1000;

    public SpaceWhales(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; set; }

    public void DoDamage(ISpaceShip ship)
    {
        ship.TakeDamage(new Damage(DamageType.Physical, SpaceWhalePhysicalDamage * Amount));
    }
}