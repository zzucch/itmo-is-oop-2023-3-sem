using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public class Deflector : IDeflector
{
    private readonly IDeflectionStrategy _deflectionStrategy;
    private int _hitPointsLeft = 1000;

    public Deflector(IPhysicalDeflectionStrategy deflectionStrategy)
    {
        _deflectionStrategy = deflectionStrategy;
    }

    public DeflectionResult TryDeflect(Damage damage)
    {
        (bool success, _hitPointsLeft) = _deflectionStrategy.TryDeflect(damage, _hitPointsLeft);

        return new DeflectionResult(success, DeflectingEntityDestroyed: _hitPointsLeft == 0);
    }
}