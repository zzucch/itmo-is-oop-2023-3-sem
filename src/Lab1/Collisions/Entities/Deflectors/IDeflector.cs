using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public interface IDeflector
{
    DeflectionResult TryDeflect(Models.Damage damage);
}