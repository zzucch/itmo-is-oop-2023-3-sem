using Itmo.ObjectOrientedProgramming.Lab1.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public interface IDeflector
{
    bool TryDeflect(Damage damage);
}