using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflectors;

public class Deflector : IDeflector
{
    public Deflector(IDeflectionStrategy deflectionStrategy)
    {
        DeflectionStrategy = deflectionStrategy;
    }

    private int HitPointsLeft { get; set; } = 1000;
    private IDeflectionStrategy DeflectionStrategy { get; }

    public DeflectionResult TryDeflect(Models.Damage damage)
    {
        (bool success, HitPointsLeft) = DeflectionStrategy.TryDeflect(damage, HitPointsLeft);

        return new DeflectionResult(success, DeflectingEntityDestroyed: HitPointsLeft == 0);
    }
}