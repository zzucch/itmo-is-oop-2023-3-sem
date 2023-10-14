using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;

public class Hull
{
    public Hull(IDeflectionStrategy deflectionStrategy, MassDimensional massDimensional)
    {
        DeflectionStrategy = deflectionStrategy;
        MassDimensional = massDimensional;
    }

    private IDeflectionStrategy DeflectionStrategy { get; }
    private MassDimensional MassDimensional { get; }
    private int HitPointsLeft { get; set; } = 500;

    public DeflectionResult TryDeflect(Damage damage)
    {
        (bool success, int hitPointsLeft) = DeflectionStrategy.TryDeflect(damage, HitPointsLeft);
        bool damageTaken = (HitPointsLeft - hitPointsLeft) > 0;
        HitPointsLeft = hitPointsLeft;

        return new DeflectionResult(success, damageTaken);
    }
}