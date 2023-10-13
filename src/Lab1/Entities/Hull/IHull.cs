using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public interface IHull
{
    public bool TryDeflect(Damage damage);
}