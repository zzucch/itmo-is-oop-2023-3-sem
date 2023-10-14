using Itmo.ObjectOrientedProgramming.Lab1.Damage.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;

public interface IDeflectionStrategy
{
    DeflectionStrategyResult TryDeflect(Models.Damage damage, int hitPoints);
}