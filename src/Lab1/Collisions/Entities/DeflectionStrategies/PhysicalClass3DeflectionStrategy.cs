using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;

public class PhysicalClass3DeflectionStrategy : IPhysicalDeflectionStrategy
{
    public DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints)
    {
        if (damage is not Damage.Physical physical)
        {
            return new DeflectionStrategyResult(Success: false, hitPoints);
        }

        if (hitPoints >= physical.Amount)
        {
            hitPoints -= physical.Amount;

            return new DeflectionStrategyResult(Success: true, hitPoints);
        }

        hitPoints = 0;

        return new DeflectionStrategyResult(Success: false, hitPoints);
    }
}