using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class Obstacle
{
    protected Obstacle()
    {
    }

    protected Obstacle(int physicalDamage)
    {
        PhysicalDamage = physicalDamage;
    }

    protected virtual int PhysicalDamage { get; }

    protected virtual void DoDamage(ISpaceShip ship)
    {
        ship.TakePhysicalDamage(PhysicalDamage);
    }
}