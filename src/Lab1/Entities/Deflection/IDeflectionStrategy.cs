using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

public interface IDeflectionStrategy
{
    DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints);
}