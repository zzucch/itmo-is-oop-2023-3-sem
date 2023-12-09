using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public abstract class DeflectorDecorator : IDeflector
{
    private readonly IDeflector _deflector;

    protected DeflectorDecorator(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public virtual DeflectionResult TryDeflect(Damage damage)
    {
        return _deflector.TryDeflect(damage);
    }
}