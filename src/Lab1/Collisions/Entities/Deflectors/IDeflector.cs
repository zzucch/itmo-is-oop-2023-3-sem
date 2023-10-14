using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public interface IDeflector
{
    DeflectionResult TryDeflect(Damage damage);
}