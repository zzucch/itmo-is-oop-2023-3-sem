using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IDeflector
{
    bool TryDeflect(Damage damage);
}