using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;

public interface IDeflectionStrategy
{
    DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints);
}