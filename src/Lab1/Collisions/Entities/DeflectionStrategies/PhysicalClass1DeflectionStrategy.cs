using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;

public class PhysicalClass1DeflectionStrategy : IPhysicalDeflectionStrategy
{
    private const DamageType DeflectionType = DamageType.Physical;
    private const int DeflectionCoefficient = 40;

    public DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints)
    {
        if (damage.Type is not DeflectionType)
        {
            return new DeflectionStrategyResult(Success: false, hitPoints);
        }

        if (hitPoints >= damage.Amount * DeflectionCoefficient)
        {
            hitPoints -= damage.Amount * DeflectionCoefficient;

            return new DeflectionStrategyResult(Success: true, hitPoints);
        }

        hitPoints = 0;

        return new DeflectionStrategyResult(Success: false, hitPoints);
    }
}