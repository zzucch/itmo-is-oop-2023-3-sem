using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflection;

public class PhysicalClass1DeflectionStrategy : IDeflectionStrategy
{
    private const DamageType DeflectionType = DamageType.Physical;
    private const int DeflectionCoefficient = 40;

    public DeflectionStrategyResult TryDeflect(Models.Damage damage, int hitPoints)
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