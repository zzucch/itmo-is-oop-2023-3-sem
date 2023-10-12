using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class Deflector : IDeflector
{
    public Deflector(IDeflectionStrategy deflectionStrategy)
    {
        DeflectionStrategy = deflectionStrategy;
    }

    private int HitPoints { get; set; } = 1000;
    private IDeflectionStrategy DeflectionStrategy { get; init; }

    public bool TryDeflect(Damage damage)
    {
        (bool success, HitPoints) = DeflectionStrategy.TryDeflect(damage, HitPoints);

        return success;
    }
}