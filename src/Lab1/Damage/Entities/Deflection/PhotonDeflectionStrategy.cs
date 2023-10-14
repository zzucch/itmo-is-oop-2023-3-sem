using Itmo.ObjectOrientedProgramming.Lab1.Damage.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;

public class PhotonDeflectionStrategy : IDeflectionStrategy
{
    private const DamageType DeflectionType = DamageType.Photon;

    public DeflectionStrategyResult TryDeflect(Models.Damage damage, int hitPoints)
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