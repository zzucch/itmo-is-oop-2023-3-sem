using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public abstract class DeflectorDecorator : IDeflector
{
    protected DeflectorDecorator(IDeflector deflector)
    {
        Deflector = deflector;
    }

    private IDeflector Deflector { get; }

    public virtual DeflectionResult TryDeflect(Models.Damage damage)
    {
        return Deflector.TryDeflect(damage);
    }
}