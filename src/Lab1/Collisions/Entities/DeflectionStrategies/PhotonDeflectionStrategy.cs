using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;

public class PhotonDeflectionStrategy : IDeflectionStrategy
{
    public DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints)
    {
        if (damage is not Damage.Photon photon)
        {
            return new DeflectionStrategyResult(Success: false, hitPoints);
        }

        if (hitPoints >= photon.Amount)
        {
            hitPoints -= photon.Amount;

            return new DeflectionStrategyResult(Success: true, hitPoints);
        }

        hitPoints = 0;

        return new DeflectionStrategyResult(Success: false, hitPoints);
    }
}