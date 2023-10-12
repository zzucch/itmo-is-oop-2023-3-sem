using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorDecorator : IDeflector
{
    protected DeflectorDecorator(IDeflector deflector)
    {
        Deflector = deflector;
    }

    private IDeflector Deflector { get; }

    public virtual bool TryDeflect(Damage damage)
    {
        return Deflector.TryDeflect(damage);
    }
}