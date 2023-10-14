using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public abstract class DeflectorDecorator : IDeflector
{
    protected DeflectorDecorator(IDeflector deflector)
    {
        Deflector = deflector;
    }

    private IDeflector Deflector { get; }

    public virtual DeflectionResult TryDeflect(Damage damage)
    {
        return Deflector.TryDeflect(damage);
    }
}