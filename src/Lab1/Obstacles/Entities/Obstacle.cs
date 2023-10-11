using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public abstract class Obstacle
{
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