using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class Deflector : IDeflector
{
    public Deflector(IDeflectionStrategy deflectionStrategy)
    {
        DeflectionStrategy = deflectionStrategy;
    }

    private int HitPointsLeft { get; set; } = 1000;
    private IDeflectionStrategy DeflectionStrategy { get; }

    public DeflectionResult TryDeflect(Damage damage)
    {
        (bool success, HitPointsLeft) = DeflectionStrategy.TryDeflect(damage, HitPointsLeft);

        return new DeflectionResult(success, DeflectingEntityDestroyed: HitPointsLeft == 0);
    }
}