using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

public interface IDeflectionStrategy
{
    DeflectionStrategyResult TryDeflect(Damage damage, int hitPoints);
}