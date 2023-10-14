using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflectors;

public interface IDeflector
{
    DeflectionResult TryDeflect(Models.Damage damage);
}