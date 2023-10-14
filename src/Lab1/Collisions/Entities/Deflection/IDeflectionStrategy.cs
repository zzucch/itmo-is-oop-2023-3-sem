using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflection;

public interface IDeflectionStrategy
{
    DeflectionStrategyResult TryDeflect(Models.Damage damage, int hitPoints);
}