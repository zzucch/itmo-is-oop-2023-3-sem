using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

public class PhysicalClass2DeflectionStrategy : IDeflectionStrategy
{
    private const DamageType DeflectionType = DamageType.Physical;
    private const int LowDamage = 50;
    private const int MediumDamage = 500;
    private const int LowDeflectionCoefficient = 4;
    private const int MediumDeflectionCoefficient = 3;
    private const int HighDeflectionCoefficient = 100;

    public DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints)
    {
        if (damage.Type is not DeflectionType)
        {
            return new DeflectionStrategyResult(Success: false, hitPoints);
        }

        int damageAmount = damage.Amount;

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