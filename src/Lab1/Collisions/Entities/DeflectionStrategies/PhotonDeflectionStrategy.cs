using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;

public class PhotonDeflectionStrategy : IDeflectionStrategy
{
    private const DamageType DeflectionType = DamageType.Photon;

    public DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints)
    {
        if (damage.Type is not DeflectionType)
        {
            return new DeflectionStrategyResult(Success: false, hitPoints);
        }

        if (hitPoints >= damage.Amount)
        {
            hitPoints -= damage.Amount;

            return new DeflectionStrategyResult(Success: true, hitPoints);
        }

        hitPoints = 0;

        return new DeflectionStrategyResult(Success: false, hitPoints);
    }
}