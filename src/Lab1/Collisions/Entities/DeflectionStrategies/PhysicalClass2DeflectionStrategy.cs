using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;

public class PhysicalClass2DeflectionStrategy : IPhysicalDeflectionStrategy
{
    private const int LowDamage = 50;
    private const int MediumDamage = 500;
    private const int LowDeflectionCoefficient = 4;
    private const int MediumDeflectionCoefficient = 3;
    private const int HighDeflectionCoefficient = 100;

    public DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints)
    {
        if (damage is not Damage.Physical physical)
        {
            return new DeflectionStrategyResult(Success: false, hitPoints);
        }

        int damageAmount = physical.Amount;

        damageAmount *= damageAmount switch
        {
            < LowDamage => LowDeflectionCoefficient,
            < MediumDamage => MediumDeflectionCoefficient,
            >= MediumDamage => HighDeflectionCoefficient,
        };

        if (hitPoints >= damageAmount)
        {
            hitPoints -= damageAmount;

            return new DeflectionStrategyResult(Success: true, hitPoints);
        }

        hitPoints = 0;

        return new DeflectionStrategyResult(Success: false, hitPoints);
    }
}