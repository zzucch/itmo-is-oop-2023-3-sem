using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class Deflector : IDeflector
{
    public Deflector(IDeflectionStrategy deflectionStrategy)
    {
        DeflectionStrategy = deflectionStrategy;
    }

    private int HitPoints { get; set; } = 100;
    private IDeflectionStrategy DeflectionStrategy { get; init; }

    public bool TryDeflect(Damage damage)
    {
        return DeflectionStrategy.TryDeflect(damage, HitPoints);
    }
}