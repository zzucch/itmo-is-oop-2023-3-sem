using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;

public class Hull : IHull
{
    private readonly IDeflectionStrategy _deflectionStrategy;
    private int _hitPointsLeft = 500;

    public Hull(IPhysicalDeflectionStrategy deflectionStrategy)
    {
        _deflectionStrategy = deflectionStrategy;
    }

    public DeflectionResult TryDeflect(Damage damage)
    {
        (bool success, int hitPointsLeft) = _deflectionStrategy.TryDeflect(damage, _hitPointsLeft);
        bool damageTaken = (_hitPointsLeft - hitPointsLeft) > 0;
        _hitPointsLeft = hitPointsLeft;

        return new DeflectionResult(success, damageTaken);
    }
}