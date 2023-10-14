using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IDeflector
{
    DeflectionResult TryDeflect(Damage damage);
}