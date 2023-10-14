using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

public interface IDeflectionStrategy
{
    DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints);
}