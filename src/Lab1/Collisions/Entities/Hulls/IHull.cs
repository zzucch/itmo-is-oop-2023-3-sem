using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;

public interface IHull
{
    public DeflectionResult TryDeflect(Damage damage);
}